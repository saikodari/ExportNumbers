$(document).ready(function () {
    debugger;
    loadExstingNumbers();
    $('#exportJsonBtn').click(function () {
        $.ajax({
            url: '/NumbersSorting/ExportSortedSequences',
            type: 'GET',
            success: function (response) {
                var jsonString = JSON.stringify(response);
                var blob = new Blob([jsonString], { type: 'application/json' });
                var a = document.createElement('a');
                a.href = window.URL.createObjectURL(blob);
                a.download = 'sorted_sequences.json';
                a.click();
            },
            error: function (xhr, status, error) {
                toastr.error("Failed to export sorted sequences as JSON", 'Error', { "closeButton": true });
            }
        });
    });

    $('#sortForm').submit(function (e) {
        e.preventDefault();
        var formData = $(this).serialize();
        $.ajax({
            url: '/NumbersSorting/Sort',
            type: 'POST',
            data: formData,
            success: function (response) {
                toastr.success(response.message, 'Success', { "closeButton": true });
                loadExstingNumbers();
            },
            error: function (xhr, status, error) {
                toastr.error("Something went wrong", 'Error', { "closeButton": true });
            }
        });
    });
    function loadExstingNumbers() {
        $('#DisplaySortedSequences').load('/NumbersSorting/DisplaySortedSequences');
    }
});
