$(document).ready(function () {
    $('.form-image').click(function () { $('#customFile').trigger('click'); });
    $(function () {
        $('.selectpicker').selectpicker();
    });
    setTimeout(function () {
        $('body').addClass('loaded');
    }, 200);

    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                    window.location = res.redirectUrl;
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalOptionsAction = form => {
        try { 
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,  
                success: function (res) {
                    if (res.isValid) {
                        $('#form-modal').modal('hide');
                         if (res.actionType == "reload") {
                             var datatable = $('#kt_datatable').KTDatatable();
                             datatable.reload();
                         }
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
        //prevent default form submit event
        return false;
    }
    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#viewAll').html(res.html);
                        $('#form-modal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#viewAll').html(res.html);
                        $('#form-modal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalPostForms = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) { 
                    if (res.isValid) {
                        $('#form-modal').modal('hide');
                            window.location = res.redirectUrl;
                        } 
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalDelete = form => {
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {
                            $('#viewAll').html(res.html)
                        }
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }
    jQueryWizerdFormPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        uppy.upload();
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryDataTableModalDelete = form => {
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {
                            var datatable = $('#kt_datatable').KTDatatable();
                            datatable.reload();
                        }
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }
    jQueryModalConfirm = (url, title) => {
        $('#confirm-modal .modal-content form').attr('action', url);
        $('#confirm-modal .modal-body').text(title);
        $('#confirm-modal').modal('show');
    }
    jQueryModalDeleteAction = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#confirm-modal').modal('hide');
                        if (res.actionType == "redirect") {
                            window.location = res.redirectUrl;
                        }
                        else if (res.actionType == "remove") {
                            $(res.elementId).remove();
                        }
                        else if (res.actionType == "reload") {
                            var datatable = $("#" + res.elementId).KTDatatable();
                            datatable.reload();
                        }
                        else if (res.actionType == "reload_html") {
                            $('#viewAll').html(res.html);
                        }
                        else if (res.actionType == "reload_calendar") {
                            RenderCalendar();
                        }
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
        //prevent default form submit event
        return false;
    }
    jQueryModalPostEditor = form => {
        try {
            var formData = new FormData(form)
            formData.append('Body', editor.getData());
            $.ajax({
                type: 'POST',
                url: form.action,
                data: formData,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalPostCalendar = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        RenderCalendar();
                        $('#form-modal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalPostOfOrders = form => {
        try {  
            $.ajax({ 
                type: 'POST',
                url: form.action,
                data: form.serialize(),
                contentType: 'application/json',
                processData: false,
                success: function (res) {
                    res.preventDefault();
                    if (res.isValid) {
                        window.location = res.redirectUrl;
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
     
    jQueryModalPostOfComments = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        $('#Notes').val('');
                        $('#commentsSide').append(res.html);
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
});