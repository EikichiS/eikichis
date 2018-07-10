$('#formRegistro').submit(funtion(e));{
    var nom =document.getElemtbyId('txtNombre');
    var ape =document.getElemtbyId('txtApellido');
    var tel = document.getElemtbyId('txtTelefono');
    var ema = document.getElemtbyId('txtEmail');
    var men = document.getElemtbyId('txtMensaje');

	if (!nom.value || !ape.value || !tel.value || !ema.value || !men.value) {

	    alertify.error('todos los campos son requeridos');
	}else{

	    $.ajax({

	        url:"https://formspree.io/alfonsoulloa.o@gmail.com",
	        method: "POST",
	        data: $(this).serialize(),
	        dataType:"json"

	    })



			e.prevenDefault();
			$(this).get().reset();
			alertify.success('Informacion enviada');

	}


}