// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#example').DataTable({
        autoWidth: false,
        responsive: true,
        "language": {
            "processing": "Procesando...",
            "lengthMenu": "Mostrando _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_",            
            "loadingRecords": "Cargando...",
            "search": "Buscar:",
            "infoFiltered": "(filtrado de un total de _MAX_ total registros)",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }


    });
    
});
