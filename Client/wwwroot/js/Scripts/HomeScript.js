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
}, "konsumenChart", am4charts.PieChart);

function exportXLS() {
    Konsumenchart.exporting.export("xlsx");
}
function exportPDF() {
    Konsumenchart.exporting.export("pdf");
}

// Create chart instance
var chart = am4core.create("carChart", am4charts.XYChart);

// Increase contrast by taking evey second color
chart.colors.step = 2;
// Add data
chart.data = getDataLine();
// Set input format for the dates
chart.dateFormatter.inputDateFormat = "yyyy-MM-dd";
// Create axes
var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
/* dateAxis.renderer.grid.template.location = 0; */
/* dateAxis.renderer.minGridDistance = 50; */
dateAxis.renderer.grid.template.disabled = true;
/* dateAxis.renderer.fullWidthTooltip = true; */
var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
// Create series
var series = chart.series.push(new am4charts.LineSeries());
series.dataFields.valueY = "durasi";
series.dataFields.dateX = "date";
series.tooltipText = "{value}"
series.strokeWidth = 2;
series.minBulletDistance = 15;

// Drop-shaped tooltips
series.tooltip.background.cornerRadius = 20;
series.tooltip.background.strokeOpacity = 0;
series.tooltip.pointerOrientation = "vertical";
series.tooltip.label.minWidth = 40;
series.tooltip.label.minHeight = 40;
series.tooltip.label.textAlign = "middle";
series.tooltip.label.textValign = "middle";

// Make bullets grow on hover
var bullet = series.bullets.push(new am4charts.CircleBullet());
bullet.circle.strokeWidth = 2;
bullet.circle.radius = 4;
bullet.circle.fill = am4core.color("#fff");

var bullethover = bullet.states.create("hover");
bullethover.properties.scale = 1.3;

// Make a panning cursor
chart.cursor = new am4charts.XYCursor();
chart.cursor.behavior = "panXY";
chart.cursor.xAxis = dateAxis;
chart.cursor.snapToSeries = series;
chart.cursor.fullWidthLineX = true;
chart.cursor.lineX.strokeOpacity = 0;
chart.cursor.lineX.fill = am4core.color("#000");
chart.cursor.lineX.fillOpacity = 0.1;

// Create a horizontal scrollbar with previe and place it underneath the date axis
chart.scrollbarX = new am4charts.XYChartScrollbar();
chart.scrollbarX.series.push(series);
chart.scrollbarX.parent = chart.bottomAxesContainer;

dateAxis.start = 0.79;
dateAxis.keepSelection = true;

function getDataLine() {
    var arrData = [];
    $.ajax({
        type: 'GET',
        url: "/reserves/LoadReserve/",
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
            return arrData;
        }
    });
}
getDataLine();

// =================================================================
//// Create chart instance
//var chart = am4core.create("carChart", am4charts.XYChart);

//// Increase contrast by taking evey second color
//chart.colors.step = 2;

//// Add data
//chart.data = generateChartData();
////chart.data = getDataLine();

//// Create axes
//var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
//dateAxis.renderer.minGridDistance = 50;

//// Create series
//function createAxisAndSeries(field, name, opposite, bullet) {
//    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
//    if (chart.yAxes.indexOf(valueAxis) != 0) {
//        valueAxis.syncWithAxis = chart.yAxes.getIndex(0);
//        //console.log(chart.yAxes)
//    }

//    var series = chart.series.push(new am4charts.LineSeries());
//    series.dataFields.valueY = field;
//    series.dataFields.dateX = "date";
//    series.strokeWidth = 2;
//    series.yAxis = valueAxis;
//    series.name = name;
//    series.tooltipText = "{name}: [bold]{valueY}[/]";
//    series.tensionX = 0.8;
//    series.showOnInit = true;

//    var interfaceColors = new am4core.InterfaceColorSet();

//    switch (bullet) {
//        case "triangle":
//            var bullet = series.bullets.push(new am4charts.Bullet());
//            bullet.width = 12;
//            bullet.height = 12;
//            bullet.horizontalCenter = "middle";
//            bullet.verticalCenter = "middle";

//            var triangle = bullet.createChild(am4core.Triangle);
//            triangle.stroke = interfaceColors.getFor("background");
//            triangle.strokeWidth = 2;
//            triangle.direction = "top";
//            triangle.width = 12;
//            triangle.height = 12;
//            break;
//        case "rectangle":
//            var bullet = series.bullets.push(new am4charts.Bullet());
//            bullet.width = 10;
//            bullet.height = 10;
//            bullet.horizontalCenter = "middle";
//            bullet.verticalCenter = "middle";

//            var rectangle = bullet.createChild(am4core.Rectangle);
//            rectangle.stroke = interfaceColors.getFor("background");
//            rectangle.strokeWidth = 2;
//            rectangle.width = 10;
//            rectangle.height = 10;
//            break;
//        default:
//            var bullet = series.bullets.push(new am4charts.CircleBullet());
//            bullet.circle.stroke = interfaceColors.getFor("background");
//            bullet.circle.strokeWidth = 2;
//            break;
//    }

//    valueAxis.renderer.line.strokeOpacity = 1;
//    valueAxis.renderer.line.strokeWidth = 2;
//    valueAxis.renderer.line.stroke = series.stroke;
//    valueAxis.renderer.labels.template.fill = series.stroke;
//    valueAxis.renderer.opposite = opposite;

//    // Create a horizontal scrollbar with previe and place it underneath the date axis
//    chart.scrollbarX = new am4charts.XYChartScrollbar();
//    chart.scrollbarX.series.push(series);
//    chart.scrollbarX.parent = chart.bottomAxesContainer;

//    dateAxis.start = 0.79;
//    dateAxis.keepSelection = true;
//}

//// Add legend
//chart.legend = new am4charts.Legend();

//createAxisAndSeries("days", "Durasi", false, "circle");
//createAxisAndSeries("visits", "Visits", false, "circle");
////createAxisAndSeries("views", "Views", true, "triangle");
////createAxisAndSeries("hits", "Hits", true, "rectangle");

//// Add cursor
//chart.cursor = new am4charts.XYCursor();

//// generate some random data, quite different range
//function generateChartData() {
//    var chartData = [];
//    var firstDate = new Date();
//    firstDate.setDate(firstDate.getDate() - 100);
//    firstDate.setHours(0, 0, 0, 0);

//    var visits = 1600;
//    var hits = 2900;
//    var views = 8700;

//    for (var i = 0; i < 15; i++) {
//        // we create date objects here. In your data, you can have date strings
//        // and then set format of your dates using chart.dataDateFormat property,
//        // however when possible, use date objects, as this will speed up chart rendering.
//        var newDate = new Date(firstDate);
//        newDate.setDate(newDate.getDate() + i);

//        visits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
//        hits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
//        views += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);

//        chartData.push({
//            date: newDate,
//            visits: visits,
//            hits: hits,
//            views: views
//        });
//    }
//    //console.log(chartData);
//    return chartData;
//}
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