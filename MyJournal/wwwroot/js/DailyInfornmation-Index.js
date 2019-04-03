$(".stat").click(function() {
    $('.stat').not(this).each(function() {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
});

let global = {
    chartName: "myChart",
    time: "day",
    moodByMonth: [],
    moodByDay: [],
    sleepByMonth: [],
    sleepByDay: [],
    workOutByMonth: [],
    workOutByDay: [],
    dateLabels: [],
    options: {
        scales: {
            yAxes: [{
                display: true,
                ticks: {
                    suggestedMin: 1,
                    stepSize: 1
                }
            }]
        },
        legend: {
            display: false
        },
        title: {
            display: true,
            text: 'Default'
        }
    }
}

function moodGraph(time) {
    let _options = $.extend(true, {}, global.options);
    _options.title.text = "Mood by " + time;

    if (time == "month") {
        preGraph(3, global.dateLabels, global.moodByMonth, _options);
    } else {
        preGraph(1, global.dateLabels, global.moodByDay, _options);
    }
}

function WorkingOutGraph(time) {
    let _options = $.extend(true, {}, global.options);
    _options.title.text = "Minutes Exercising by " + time;
    _options.scales.yAxes[0].ticks.stepSize = 15;

    if (time == "month") {
        preGraph(3, global.dateLabels, global.workOutByMonth, _options);
    } else {
        preGraph(1, global.dateLabels, global.workOutByDay, _options);
    }
}

function SleepGraph(time) {
    let _options = $.extend(true, {}, global.options);
    _options.title.text = "Hours of Sleep by " + time;
    _options.scales.yAxes[0].ticks.stepSize = 1;

    if (time == "month") {
        preGraph(3, global.dateLabels, global.sleepByMonth, _options);
    } else {
        preGraph(1, global.dateLabels, global.sleepByDay, _options);
    }
}

function AverageMoodGraph() {
    let _options = $.extend(true, {}, global.options);
    _options.title.text = "Total Moods";
    preGraph(2, ["Mood: 1", "Mood: 2", "Mood: 3", "Mood: 4", "Mood: 5"], global.moodByCount, _options);
}


function ChangeLinkType(type) {
    $(".page-item a").attr("href")
    $(".page-item a").each(function() {
        var $this = $(this);
        var _href = $this.attr("href");
        $this.attr("href", _href.split("&")[0] + '&curr=' + type);
    });
}

$("#mood").click(function() {
    ChangeLinkType("mood");
    Graph(global.time, "mood");
});

$("#overalMood").click(function() {
    ChangeLinkType("averageMood");
    AverageMoodGraph();
});

$("#workingOut").click(function() {
    ChangeLinkType("workingOut");
    WorkingOutGraph(global.time);
});

$("#sleep").click(function() {
    ChangeLinkType("sleep");
    SleepGraph(global.time);
});