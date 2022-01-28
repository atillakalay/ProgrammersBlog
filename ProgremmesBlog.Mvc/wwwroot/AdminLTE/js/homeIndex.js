$(document).ready(function () {
    // DataTable
    $('#articlesTable').DataTable({
        "order": [[4, "desc"]],
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
        },

    });
    // DataTable

    // Chart.js

    $.get('/Admin/Article/GetAllByViewCount/?isAscending=false&takeSize=10',
        function (data) {
            const articleResult = jQuery.parseJSON(data);

            let viewsCountContext = $('#viewCountChart');

            let viewsCountChart = new Chart(viewsCountContext,
                {
                    type: 'bar',
                    data: {
                        labels: articleResult.$values.map(article => article.Title),
                        datasets: [
                            {
                                label: 'Okunma Sayısı',
                                data: articleResult.$values.map(article => article.ViewsCount),
                                backgroundColor: '#fb3640',
                                hoverBorderWidth: 4,
                                hoverBorderColor: 'black'
                            },
                            {
                                label: 'Yorum Sayısı',
                                data: articleResult.$values.map(article => article.CommentCount),
                                backgroundColor: '#fdca40',
                                hoverBorderWidth: 4,
                                hoverBorderColor: 'black'
                            }]
                    },
                    options: {
                        plugins: {
                            legend: {
                                labels: {
                                    font: {
                                        size: 18
                                    }
                                }
                            }
                        }
                    }
                });
        });

});