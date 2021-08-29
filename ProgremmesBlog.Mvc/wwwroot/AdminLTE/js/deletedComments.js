$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#deletedCommentsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Comment/GetAllDeletedComments/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#deletedCommentsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(commentResult);
                            if (commentResult.Data) {
                                const articlesArray = [];
                                $.each(commentResult.Data.Comments.$values,
                                    function (index, comment) {
                                        const newComment = getJsonNetObject(comment, commentResult.Data.Comments.$values);
                                        let newArticle = getJsonNetObject(newComment.Article, newComment);
                                        if (newArticle !== null) {
                                            articlesArray.push(newArticle);
                                        }
                                        if (newArticle === null) {
                                            newArticle = articlesArray.find((article) => {
                                                return article.$id === newComment.Article.$ref;
                                            });
                                        }
                                        const newTableRow = dataTable.row.add([
                                            newComment.Id,
                                            newArticle.Title,
                                            newComment.Text.length > 75 ? newComment.Text.substring(0, 75) : newComment.Text,
                                            `${newComment.IsActive ? "Evet" : "Hayır"}`,
                                            `${newComment.IsDeleted ? "Evet" : "Hayır"}`,
                                            `${convertToShortDate(newComment.CreatedDate)}`,
                                            newComment.CreatedByName,
                                            `${convertToShortDate(newComment.ModifiedDate)}`,
                                            newComment.ModifiedByName,
                                            `
                                <button class="btn btn-warning btn-sm btn-undo" data-id="${newComment.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newComment.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newComment.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#deletedCommentsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${commentResult.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#deletedCommentsTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax POST / Deleting a Comment starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let commentText = tableRow.find('td:eq(2)').text();
            commentText = commentText.length > 75 ? commentText.substring(0, 75) : commentText;
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `${commentText} içerikli yorum kalıcı olarak silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, kalıcı olarak silmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/HardDelete/',
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            console.log(commentResult);
                            if (commentResult.ResultStatus===0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${commentResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${commentResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });

    /* Ajax POST / Deleting a Comment ends here */


    /* Ajax POST / UndoDeleting a Comment starts from here */

    $(document).on('click',
        '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let commentText = tableRow.find('td:eq(2)').text();
            commentText = commentText.length > 75 ? commentText.substring(0, 75) : commentText;
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${commentText} içerikli yorum arşivden geri getirilecektir!`,
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, arşivden geri getirmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/UndoDelete/',
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            console.log(commentResult);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${commentResult.Data.Comment.Id} no'lu yorum arşivden geri getirilmiştir.`,
                                    'success'
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `Beklenmedik bir hata oluştu.`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });
    /* Ajax POST / UndoDeleting a Comment starts ends here */
});