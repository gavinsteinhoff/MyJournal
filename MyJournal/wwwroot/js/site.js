//Code For Report Charts
let chart;

function preGraph(chartType, labels, data, options) {
    if (chart) {
        chart.destroy();
    }

    switch (chartType) {
        case 1:
            createLineChart(labels, data, options);
            break;
        case 2:
            createDoughnutChart(labels, data, options);
            break;
    }
}

function createLineChart(labels, data, options) {
    let average = 0;
    let averageArray = [];
    $.each(data, function (key, value) {
        average += value;
    });
    average = average / data.length;
    average = average.toFixed(1);
    $.each(labels, function () {
        averageArray.push(average);
    });

    chart = new Chart(document.getElementById(global.chartName), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    borderColor: "#38a9e4",
                    data: data,
                    fill: false
                },
                {
                    borderColor: "#fff000",
                    data: averageArray,
                    fill: false
                }
            ]
        },
        options: options
    });
}

function createDoughnutChart(labels, data, options) {
    if (chart) {
        chart.destroy();
    }
    chart = new Chart(document.getElementById(global.chartName), {
        type: 'doughnut',
        data: {
            labels: labels,
            datasets: [{
                borderColor: "#000000",
                data: data,
                backgroundColor: [
                    "#ff0000",
                    "#ff7b00",
                    "#ffff00",
                    "#8cff00",
                    "#13a520",
                ],
            }]
        },
        options: options
    });
}
//End