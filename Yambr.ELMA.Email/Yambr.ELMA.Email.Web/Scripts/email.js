
yambremail = {
    contractorStat: function (container, id, text) {

        var url = "/Yambr.ELMA.Email.Web/EmailStats/Contractor/" + id;
        container = $(container);

        $.ajax({
            url: url,
            type: 'GET',
            success: function (data) {

                var chartData = [];

                $.each(data,
                    function (i, el) {
                        var date = Date.UTC(el.year, el.month, 1);
                        chartData.push([date, el.count]);
                    });
                if (chartData.length > 0) {
                    var series = [
                        {
                            type: 'column',
                            name: 'Письма по месяцам',
                            data: chartData
                        }
                    ];
                    $(function () {
                        // Create the chart
                        container.highcharts('StockChart', {
                            chart: {
                                type: 'column',
                                style: { "fontFamily": "Tahoma, Arial, Helvetica, sans-serif" },
                                alignTicks: false
                            },
                            navigator: {
                                enabled: false
                            },
                            scrollbar: {
                                enabled: false
                            },
                            rangeSelector: {
                                enabled: false
                            },
                            title: {
                                text: text
                            },
                            plotOptions: {
                                series: {
                                    dataLabels: {
                                        enabled: true,
                                        format: '<span style="font-weight: 500"><b>{point.y}<b/></span>',
                                        style: {
                                            fontWeight: 500
                                        }
                                    },
                                    point: {
                                        events: {
                                            click: function () {
                                                yambremail.openColumn(this.x);
                                            }
                                        }
                                    }
                                }
                            },
                            tooltip: {
                                pointFormat: '<span style="color:{point.color}">{point.money}</span><b>{point.y}</b>'
                            },
                            series: series
                        });
                    });
                } else {
                    container.html("<h3>Писем нет</h3>");
                }
            }
        });
    },
    openColumn: function (col) {
        console.warn(col);
    }
}
