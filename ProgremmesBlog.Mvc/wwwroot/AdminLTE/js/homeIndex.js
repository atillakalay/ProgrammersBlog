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
    const categories = [
        {
            name: 'C#',
            viewCount: '24500'
        },
        {
            name: 'C++',
            viewCount: '77000'
        },
        {
            name: 'Javascript',
            viewCount: '57800'
        },
        {
            name: 'Dart',
            viewCount: '2250'
        },
        {
            name: 'PHP',
            viewCount: '123000'
        },
        {
            name: 'Typescript',
            viewCount: '18999'
        }
    ];


    let viewCountContext = $('#viewCountChart');

    let viewCountChart = new Chart(viewCountContext,
        {
            type: 'bar',
            data: {
                labels: categories.map(category => category.name),
                datasets: [
                    {
                        label: 'Okunma Sayısı',
                        data: categories.map(category => category.viewCount),
                        backgroundColor: ['#845ec2', '#ffc75f', '#f9f871', '#ff5e78', '#a4ebf3'],
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