/*When clicking on Full hide fail/success boxes */

function setCurrentSankashti()
{
	
	var d = new Date();
	
	var currentMonth = d.getMonth() + 1;
	var currentDate = d.getDate();
	var sankasthiDate = $("#mth" + currentMonth).attr("sdate");
		
	if (sankasthiDate < currentDate && currentMonth < 12) {
		currentMonth = currentMonth + 1;
	}
	
	$("#mth" + currentMonth).css("font-weight", "bold");
	$("#mth" + currentMonth).addClass("success");
}