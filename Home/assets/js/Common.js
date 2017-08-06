notify = {
    success: (texto, header) => {
        $.toast({
            heading: header,
            text: texto,
            position: 'bottom-left',
            stack: false,
            icon: 'success',
            loader: false
        });
    },
    error: (texto, header) => {
        $.toast({
            heading: header,
            text: texto,
            position: 'bottom-left',
            stack: false,
            icon: 'error',
            loader: false
        });
    },
    warn: (texto, header) => {
        $.toast({
            heading: header,
            text: texto,
            position: 'bottom-left',
            stack: false,
            icon: 'warning',
            loader: false
        });

    }
}

String.prototype.toDate = () =>{
    var from = $(this).val().split("/");
    var f = new Date(from[2], from[1] - 1, from[0]);
    return f;
}