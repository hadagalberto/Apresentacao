const confirmDelete = id => {
    $('#itemDelete').val(id);
    $('#modalDelete').modal('show');
}