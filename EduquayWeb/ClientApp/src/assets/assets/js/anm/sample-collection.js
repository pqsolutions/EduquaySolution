function myFunction() {
  var checkBox = document.getElementById("myCheck");
  var text = document.getElementById("text");
  if (checkBox.checked == true) {
    text.style.display = "block";
  } else {
    text.style.display = "none";
  }
}

function myDefinition() {
  var x = document.getElementById("myTable");
  if (x.style.display === "none") {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}
$('#zero-config').DataTable({
  "oLanguage": {
    "oPaginate": { "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>', "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>' },
    "sInfo": "Showing page _PAGE_ of _PAGES_",
    "sSearch": '<div><span class="note">Search by any Subject information from below</span></div><div><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg></div>',
    "sSearchPlaceholder": "Search...",
    "sEmptyTable": "No collection data available",
    "sLengthMenu": "Records / Page :  _MENU_",
  },
  "stripeClasses": [],
  "lengthMenu": [10, 20, 50],
  "pageLength": 10
});

var f1 = flatpickr(document.getElementById('popupDate'), {
  dateFormat: "d/m/Y",
  defaultDate: "today"
});

var f2 = flatpickr(document.getElementById('popupTime'), {
  enableTime: true,
  noCalendar: true,
  dateFormat: "H:i",
  defaultDate: "today"
});