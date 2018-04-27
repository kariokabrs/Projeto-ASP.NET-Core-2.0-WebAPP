$('#Salvar').click(function () {
   
    var url = "/usuarios/additem";
    var nome = $("#Nome").val();
   
    $.post(url, { Nome: nome, }, function (data) {
      
        $("#msg").html(data);
       
    });
    
})