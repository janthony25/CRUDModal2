$(document).ready(function () {
    GetCustomers();
});

function GetCustomers() {
    $.ajax({
        url: '/customer/GetCustomers',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=urf-8',
        success: function (response) {
            let tableRows = '';

            if (response == null || response == undefined || response.length == 0) {
                tableRows = `
                    <tr>
                        <td class="text-center" colspan="5">No customers found.</td>
                    </tr>`;
            }
            else {
                // get all customers
                $.each(response, function (index, item) {
                    const dateAdded = new Date(item.dateAdded).toLocaleDateString();

                    tableRows += `
                        <tr>
                            <td>${item.customerId}</td>
                            <td>${item.customerName}</td>
                            <td>${item.customerEmail}</td>
                            <td>${item.customerNumber}</td>
                            <td>${dateAdded}</td>
                            <td>
                                <a href="#" class="btn btn-primary btn-sm" onclick="Edit(${item.customerId})">Edit</a>
                                <a href="#" class="btn btn-danger btn-sm" onclick="Delete(${item.customerId})">Delete</a>
                            </td>
                        </tr>`
                });
            }
            $('#tblBody').html(tableRows);
        },
        error: function () {
            alert('Unable to read data.');
        }
    });
}

$('#btnAdd').click(function () {
    $('#CustomerModal').modal('show');
    $('#modalTitle').text('Add Customer');
})

$('#btnCloseModal').click(function () {
    HideModal();
})

function AddCustomer() {

    var result = Validate();
    if (result == false) {
        return false;
    }

    var formData = new Object();
    formData.customerId = $('#CustomerId').val();
    formData.customerName = $('#CustomerName').val();
    formData.customerEmail = $('#CustomerEmail').val();
    formData.customerNumber = $('#CustomerNumber').val();

    $.ajax({
        url: '/customer/AddCustomer',
        data: formData,
        type: 'POST',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save customer.');
            }
            else {
                GetCustomers();
                HideModal();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save customer');
        }
    });
}

function HideModal() {
    ClearData();
    $('#CustomerModal').modal('hide');

   
}

function ClearData() {
   $('#CustomerId').val('');
   $('#CustomerName').val('');
   $('#CustomerEmail').val('');
    $('#CustomerNumber').val('');

    $('#CustomerName').css('border-color', 'Lightgrey');
    $('#CustomerEmail').css('border-color', 'Lightgrey');
    $('#CustomerNumber').css('border-color', 'Lightgrey');
}

function Validate() {
    var isValid = true;

    if ($('#CustomerName').val().trim() == "") {
        $('#CustomerName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CustomerName').css('border-color', 'Lightgrey');
    }

    if ($('#CustomerEmail').val().trim() == "") {
        $('#CustomerEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CustomerEmail').css('border-color', 'Lightgrey');
    }

    if ($('#CustomerNumber').val().trim() == "") {
        $('#CustomerNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CustomerNumber').css('border-color', 'Lightgrey');
    }

    return isValid;

    
}

$($('#CustomerName')).change(function () {
    Validate();
})

$($('#CustomerEmail')).change(function () {
    Validate();
})

$($('#CustomerNumber')).change(function () {
    Validate();
})

// Populate customer Details by id
function Edit(customerId) {
    $.ajax({
        url: '/customer/Edit?id=' + customerId,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Unable to read data.');
            }
            else if (response.length == 0) {
                alert(`No data available for id: ${customerId}`);
            }
            else {
                $('#CustomerModal').modal('show');
                $('#modalTitle').text('Update Customer');
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
                $('#CustomerId').val(response.customerId);
                $('#CustomerName').val(response.customerName);
                $('#CustomerEmail').val(response.customerEmail);
                $('#CustomerNumber').val(response.customerNumber);
            }
        },
        error: function () {
            alert('Unable to read data.');
        }
    });
}

function Update() {
    var result = Validate();
    if (result == false) {
        return false;
    }

    // Get the anti-forgery token value  
    var token = $('input[name="__RequestVerificationToken"]').val();

    var formData = {
        __RequestVerificationToken: token,  // Correct token assignment
        customerId: $('#CustomerId').val(),
        customerName: $('#CustomerName').val(),
        customerEmail: $('#CustomerEmail').val(),
        customerNumber: $('#CustomerNumber').val()
    };

    $.ajax({
        url: '/customer/Update',
        data: formData,
        type: 'POST',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save customer.');
            }
            else {
                GetCustomers();
                HideModal();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save customer');
        }
    });
}