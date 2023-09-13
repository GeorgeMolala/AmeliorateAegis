


function deleteContract(contractId) {


	//swal.fire({
	//    title: 'Are you sure?',
	//    text: "You won't be able to revert this action.",
	//    icon: 'warning',
	//    showCancelButton: true,
	//    confirmButtonText: 'Yes, Delete',
	//    confirmButtonColor: '#007236',
	//    cancelButtonText: 'No, cancel',
	//    reverseButtons: true,
	//    customClass: {
	//        confirmButton: "font-weight-bold btn-light-primary",

	//    }
	//}).then((result) => {
	//    if (result.isConfirmed) {
	//        console.log('Confirmed');
	$.ajax({
		type: "DELETE", //HTTP PUT Method
		url: `/Regional/Contract/DeleteContract?id=${contractId}`,
		contentType: "application/json",
		error: function (error) {
			ErrorGrowl("Error deleting event, please try again later!");
		}
	}).done(function (result) {
		if (result) {
			/*SuccessGrowl("Event successfully deleted!");*/
			location.reload()
		} else {
			/* ErrorGrowl("Error deleting event, please try again later!");*/
		}
	});
	//    } else if (result.dismiss === Swal.DismissReason.cancel) {
	//        swalWithBootstrapButtons.fire(
	//            'Cancelled',
	//            'statement was not marked as paid.',
	//            'error'
	//        )
	//    }
	//});

}


function SuccessGrowl(message) {
	$.notify({
		// options
		title: '<strong>Success!</strong>',
		message: message,
		icon: 'la la-info-circle', // success and info : la la-info-circle ; warning and danger : la la-exclamation-circle
	}, {
		// settings
		element: 'body',
		position: null,
		type: "success", // success, warning, danger, info
		allow_dismiss: false,
		newest_on_top: false,
		showProgressbar: false,
		placement: {
			from: "top",
			align: "contract"
		},
		offset: 70,
		spacing: 10,
		z_index: 999999,
		delay: 3300,
		timer: 1000,
		url_target: '_blank',
		mouse_over: null,
		animate: {
			enter: 'animated bounce', // rollIn
			exit: 'animated bounce' // rollOut
		},
		onShow: null,
		onShown: null,
		onClose: null,
		onClosed: null,
		icon_type: 'class',
	});
}


function ErrorGrowl(message) {
	$.notify({
		// options
		title: '<strong>Error!</strong>',
		message: message,
		icon: 'la la-exclamation-circle', // success and info : la la-info-circle ; warning and danger : la la-exclamation-circle
	}, {
		// settings
		element: 'body',
		position: null,
		type: "danger", // success, warning, danger, info
		allow_dismiss: false,
		newest_on_top: false,
		showProgressbar: false,
		placement: {
			from: "top",
			align: "contract"
		},
		offset: 70,
		spacing: 10,
		z_index: 999999,
		delay: 3300,
		timer: 1000,
		url_target: '_blank',
		mouse_over: null,
		animate: {
			enter: 'animated bounce', // rollIn
			exit: 'animated bounce' // rollOut
		},
		onShow: null,
		onShown: null,
		onClose: null,
		onClosed: null,
		icon_type: 'class',
	});
}