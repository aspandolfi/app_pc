// Call the dataTables jQuery plugin
$(document).ready(function () {
  $('#dataTable').DataTable({
    dom: 'Bfrtip',
    buttons: [
      'pdfHtml5', 'print'
    ]
  });
  $('#dataTableVitimas').DataTable({
    paging: false,
    searching: false,
    ordering: false,
    select: 'single',
    info: false,
    language: {
      url: 'http://cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json'
    }
  });
  $('#dataTableAutores').DataTable({
    paging: false,
    searching: false,
    ordering: false,
    select: 'single',
    info: false,
    language: {
      url: 'http://cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json'
    }
  });
  $('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Botão que acionou o modal
    var recipient = button.data('whatever') // Extrai informação dos atributos data-*
    // Se necessário, você pode iniciar uma requisição AJAX aqui e, então, fazer a atualização em um callback.
    // Atualiza o conteúdo do modal. Nós vamos usar jQuery, aqui. No entanto, você poderia usar uma biblioteca de data binding ou outros métodos.
    var modal = $(this)
    modal.find('.modal-title').text('Nova mensagem para ' + recipient)
    modal.find('.modal-body input').val(recipient)
  })
});
