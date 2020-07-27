// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart Car used
var Konsumenchart = am4core.createFromConfig({
    // Set inner radius
    "innerRadius": "50%",

    // Set data
    "dataSource": {
        "url": "/home/LoadPieChart",
        "parser": {
            "type": "JSONParser",
        },
        "reloadFrequency": 5000,
    },

    // Create series
    "series": [{
        "type": "PieSeries",
        "dataFields": {
            "value": "total",
            "category": "car",
        },
        "slices": {
            "cornerRadius": 10,
            "innerCornerRadius": 7
        },
        "hiddenState": {
            "properties": {
                // this creates initial animation
                "opacity": 1,
                "endAngle": -90,
                "startAngle": -90
            }
        },
        "children": [{
            "type": "Label",
            "forceCreate": true,
            "text": "Car",
            "horizontalCenter": "middle",
            "verticalCenter": "middle",
            "fontSize": 40
        }]
    }],

    // Add legend
    "legend": {},
}, "pieChart", am4charts.PieChart);

function exportXLS() {
    Konsumenchart.exporting.export("xlsx");
}
function exportPDF() {
    Konsumenchart.exporting.export("pdf");
}

// Generate random data
var data = [];
var visits = 10;

for (var i = 1; i < 100; i++) {
    visits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
    data.push({
        date: new Date(2018, 0, i),
        name: "name" + i,
        value: visits
    });
}

// =================================================================
// Create chart instance
var chart = am4core.create("lineChart", am4charts.XYChart);

// Increase contrast by taking evey second color
chart.colors.step = 2;

// Add data
//chart.data = generateChartData();
chart.dataSource.url = "/home/LoadLineChart";
chart.dateFormatter.inputDateFormat = "yyyy-MM-dd";

// Create axes
var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
dateAxis.renderer.minGridDistance = 50;

// Create series
function createAxisAndSeries(field, name, opposite, bullet) {
    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    //if (chart.yAxes.indexOf(valueAxis) != 0) {
    //    valueAxis.syncWithAxis = chart.yAxes.getIndex(0);
    //    //console.log(chart.yAxes)
    //}

    var series = chart.series.push(new am4charts.LineSeries());
    series.dataFields.valueY = field;
    series.dataFields.dateX = "date";
    series.strokeWidth = 2;
    series.yAxis = valueAxis;
    series.name = name;
    series.tooltipText = "{name}: [bold]{valueY}[/]";
    series.tensionX = 0.8;
    series.showOnInit = true;

    var interfaceColors = new am4core.InterfaceColorSet();

    switch (bullet) {
        case "triangle":
            var bullet = series.bullets.push(new am4charts.Bullet());
            bullet.width = 12;
            bullet.height = 12;
            bullet.horizontalCenter = "middle";
            bullet.verticalCenter = "middle";

            var triangle = bullet.createChild(am4core.Triangle);
            triangle.stroke = interfaceColors.getFor("background");
            triangle.strokeWidth = 2;
            triangle.direction = "top";
            triangle.width = 12;
            triangle.height = 12;
            break;
        case "rectangle":
            var bullet = series.bullets.push(new am4charts.Bullet());
            bullet.width = 10;
            bullet.height = 10;
            bullet.horizontalCenter = "middle";
            bullet.verticalCenter = "middle";

            var rectangle = bullet.createChild(am4core.Rectangle);
            rectangle.stroke = interfaceColors.getFor("background");
            rectangle.strokeWidth = 2;
            rectangle.width = 10;
            rectangle.height = 10;
            break;
        default:
            var bullet = series.bullets.push(new am4charts.CircleBullet());
            bullet.circle.stroke = interfaceColors.getFor("background");
            bullet.circle.strokeWidth = 2;
            break;
    }

    valueAxis.renderer.line.strokeOpacity = 1;
    valueAxis.renderer.line.strokeWidth = 2;
    valueAxis.renderer.line.stroke = series.stroke;
    valueAxis.renderer.labels.template.fill = series.stroke;
    valueAxis.renderer.opposite = opposite;

    // Create vertical scrollbar and place it before the value axis
    chart.scrollbarY = new am4core.Scrollbar();
    chart.scrollbarY.parent = chart.leftAxesContainer;
    chart.scrollbarY.toBack();
    // Create a horizontal scrollbar with previe and place it underneath the date axis
    chart.scrollbarX = new am4charts.XYChartScrollbar();
    chart.scrollbarX.series.push(series);
    chart.scrollbarX.parent = chart.bottomAxesContainer;

    //dateAxis.start = 0.79;
    dateAxis.keepSelection = true;
}

// Add legend
chart.legend = new am4charts.Legend();

createAxisAndSeries("days", "Car Durasi", false, "circle");
//createAxisAndSeries("visits", "Visits", false, "circle");
//createAxisAndSeries("views", "Views", true, "triangle");
//createAxisAndSeries("hits", "Hits", true, "rectangle");

// Add cursor
chart.cursor = new am4charts.XYCursor();

// generate some random data, quite different range
function generateChartData() {
    var chartData = [];

    var firstDate = new Date();
    firstDate.setDate(firstDate.getDate() - 100);
    firstDate.setHours(0, 0, 0, 0);

    var visits = 1600;
    var hits = 2900;
    var views = 8700;

    for (var i = 0; i < 15; i++) {
        // we create date objects here. In your data, you can have date strings
        // and then set format of your dates using chart.dataDateFormat property,
        // however when possible, use date objects, as this will speed up chart rendering.
        var newDate = new Date(firstDate);
        newDate.setDate(newDate.getDate() + i);

        visits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
        hits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
        views += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);

        chartData.push({
            date: newDate,
            visits: visits,
            hits: hits,
            views: views
        });
    }
    console.log(chartData);
    return chartData;
}
// =================================================================

function getData() {
    $.ajax({
        type: 'GET',
        url: "/reserves/LoadReserve/",
    }).then((result) => {
        console.log(result);
        var arr = [];
        //var groupedData = result.reduce(function (res, value) {
        //    res[value.carName] = res[value.carName] || [];
        //    res[value.carName].push(value);
        //    return res;
        //}, {});
        //console.log(groupedData);
        //console.log(Object.entries(groupedData).map((e) => ({ [e[0]]: e[1] })));
        //return groupedData;

        //var group = result.reduce((a, c) => (a[c.carName] = (a[c.carName] || 0) + 1, a), Object.create(null));
        var group = result.reduce((res, value) => {
            res[value.carName] = (res[value.carName] || 0) + 1;
            return res;
        }, {});
        console.log(group);
        //var groupMap = Object.entries(group).map((e) => ({ [e[0]]: e[1] }));
        //console.log(groupMap);
        //console.log(groupMap.length);
        //console.log(Object.values(group));

        for (var i = 0; i < Object.keys(group).length; i++) {
            arr.push({
                car: Object.keys(group)[i],
                total: Object.values(group)[i],
            });
        }
        console.log(arr);
        return arr;
    })
}
//console.log(getData);
//getData();

//getDataLine();
function getDataLine() {
    var arrData = [];
    $.ajax({
        type: 'GET',
        url: "/home/LoadLineChart",
        success: function (data) {
            console.log(data);
            var group = data.reduce((res, value) => {
                res[value.carName] = (res[value.carName] || 0) + 1;
                return res;
            }, {});
            //for (var i = 0; i < Object.keys(group).length; i++) {
            //    arrData.push({
            //        car: Object.keys(group)[i],
            //        total: Object.values(group)[i],
            //    });
            //}
            $.each(data, function (i, val) {
                var getStart = new Date(val.start_date);
                var getEnd = new Date(val.end_date);
                //console.log(getStart);
                var diff = new Date(getEnd - getStart);
                var days = diff / 1000 / 60 / 60 / 24;
                console.log(days);

                //arrData.push({
                //    date: getStart,
                //    durasi: days,
                //    car: Object.keys(group)[i],
                //    total: Object.values(group)[i],
                //});
                var dateStart = getStart.getFullYear() + '-' + ("0" + (getStart.getMonth() + 1)).slice(-2) + '-' + ("0" + getStart.getDate()).slice(-2);
                arrData.push({
                    date: dateStart,
                    durasi: days,
                    car: val.carName,
                });
            });
            console.log(arrData);
        }
    });
    return arrData;
}

//// Create chart
//var Linechart = am4core.createFromConfig({
//    // Set settings and data
//    "paddingRight": 20,
//    "data": data,

//    // Create X axes
//    "xAxes": [{
//        "type": "DateAxis",
//        "renderer": {
//            "grid": {
//                "location": 0
//            }
//        }
//    }],

//    // Create Y axes
//    "yAxes": [{
//        "type": "ValueAxis",
//        "tooltip": {
//            "disabled": true
//        },
//        "renderer": {
//            "minWidth": 35
//        }
//    }],

//    // Create series
//    "series": [{
//        "id": "s1",
//        "type": "LineSeries",
//        "dataFields": {
//            "dateX": "date",
//            "valueY": "value"
//        },
//        "tooltipText": "{valueY.value}",
//        "strokeWidth": 2,
//        "minBulletDistance": 15,
//        "bullets": [{
//            "children": [{
//                "type": "Circle",
//                "width": 10,
//                "height": 10,
//                "horizontalCenter": "middle",
//                "verticalCenter": "middle"
//            }]
//        }]
//    }],

//    // Add cursor
//    "cursor": {
//        "type": "XYCursor"
//    },

//    // Add horizontal scrollbar
//    "scrollbarX": {
//        "type": "XYChartScrollbar",
//        "series": ["s1"]
//    }
//}, "lineChart", am4charts.XYChart);