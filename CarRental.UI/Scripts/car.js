$(function () {

    var calendarEl = $('#calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid', 'timeGrid'],
        defaultView: 'dayGridMonth',
        defaultDate: '2019-07-07',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        }, events: [
            {
                title: 'All Day Event',
                start: '2019-07-01'
            },
            {
                title: 'Long Event',
                start: '2019-07-07',
                end: '2019-07-10'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2019-07-09T16:00:00'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2019-07-16T16:00:00'
            },
            {
                title: 'Conference',
                start: '2019-07-11',
                end: '2019-07-13'
            },
            {
                title: 'Meeting',
                start: '2019-07-12T10:30:00',
                end: '2019-07-12T12:30:00'
            },
            {
                title: 'Lunch',
                start: '2019-07-12T12:00:00'
            },
            {
                title: 'Meeting',
                start: '2019-07-12T14:30:00'
            },
            {
                title: 'Birthday Party',
                start: '2019-07-13T07:00:00'
            },
            {
                title: 'Click for Google',
                url: 'http://google.com/',
                start: '2019-07-28'
            }
        ]
    });

    calendar.render();
});

///* initialize the calendar
//    -----------------------------------------------------------------*/
////Date for the calendar events (dummy data)
//var date = new Date()
//var d    = date.getDate(),
//    m    = date.getMonth(),
//    y    = date.getFullYear()
//$('#calendar').fullCalendar({
//    minTime: "08:00:00",
//    maxTime: "18:00:00",
//    lang: "fr",
//    header    : {
//        left  : 'prev,next',
//        center: 'title',
//        right : 'month,agendaWeek',
//    },
//    buttonText: {
//        month: 'month',
//        week : 'week',
//    },
//    //Random default events
//    events    : [
//        {
//            title          : 'Paul Martin',
//            start          : new Date(y, m, d, 12),
//            end            : new Date(y, m, d+1, 18),
//            backgroundColor: '#3c8dbc', //Primary (light-blue)
//            borderColor    : '#3c8dbc', //Primary (light-blue)
//            url            : '../rent/rent.html'
//        },
//        {
//            title          : 'Noemie Laravelle',
//            start          : new Date(y, m, d - 5),
//            end            : new Date(y, m, d - 2),
//            backgroundColor: '#3c8dbc',
//            borderColor    : '#3c8dbc', 
//        },
//        {
//            title          : 'Vérification',
//            start          : new Date(y, m, 28),
//            end            : new Date(y, m, 29),
//            backgroundColor: '#f39c12', //yellow
//            borderColor    : '#f39c12', //yellow
//        },
//        {
//            title          : 'Williams Modeste',
//            start          : new Date(y, m, d-44, 12),
//            end            : new Date(y, m, d-43, 18),
//            backgroundColor: '#3c8dbc', 
//            borderColor    : '#3c8dbc',
//        },
//        {
//            title          : 'Maxime Derame',
//            start          : new Date(y, m, d-35, 12),
//            end            : new Date(y, m, d-32, 18),
//            backgroundColor: '#3c8dbc', 
//            borderColor    : '#3c8dbc', 
//        },
//        {
//            title          : 'Controle technique',
//            start          : new Date(y, 05, 28, 08),
//            end            : new Date(y, 05, 29, 12),
//            backgroundColor: '#f39c12',
//            borderColor    : '#f39c12',
//        },
//    ],
//    editable  : true,
//    droppable : true, // this allows things to be dropped onto the calendar !!!
//    drop      : function (date, allDay) { // this function is called when something is dropped

//        // retrieve the dropped element's stored Event Object
//        var originalEventObject = $(this).data('eventObject')

//        // we need to copy it, so that multiple events don't have a reference to the same object
//        var copiedEventObject = $.extend({}, originalEventObject)

//        // assign it the date that was reported
//        copiedEventObject.start           = date
//        copiedEventObject.allDay          = allDay
//        copiedEventObject.backgroundColor = $(this).css('background-color')
//        copiedEventObject.borderColor     = $(this).css('border-color')

//        // render the event on the calendar
//        // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
//        $('#calendar').fullCalendar('renderEvent', copiedEventObject, true)

//        // is the "remove after drop" checkbox checked?
//        if ($('#drop-remove').is(':checked')) {
//            // if so, remove the element from the "Draggable Events" list
//            $(this).remove()
//        }

//    }
//})

///* ADDING EVENTS */
//var currColor = '#3c8dbc' //Red by default
////Color chooser button
//var colorChooser = $('#color-chooser-btn')
//$('#color-chooser > li > a').click(function (e) {
//    e.preventDefault()
//    //Save color
//    currColor = $(this).css('color')
//    //Add color effect to button
//    $('#add-new-event').css({ 'background-color': currColor, 'border-color': currColor })
//})
//$('#add-new-event').click(function (e) {
//    e.preventDefault()
//    //Get value and make sure it is not null
//    var val = $('#new-event').val()
//    if (val.length == 0) {
//    return
//    }

//    //Create events
//    var event = $('<div />')
//    event.css({
//    'background-color': currColor,
//    'border-color'    : currColor,
//    'color'           : '#fff'
//    }).addClass('external-event')
//    event.html(val)
//    $('#external-events').prepend(event)

//    //Add draggable funtionality
//    init_events(event)

//    //Remove event from text input
//    $('#new-event').val('')
//})
//})