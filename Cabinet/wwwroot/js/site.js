// Write your JavaScript code.

function toolbarClick(args) {

    if (args.item.id === 'editInformations') {
        
        var gridInformation = document.getElementById("Grid").ej2_instances[0];
        var rowInformation = gridInformation.getSelectedRecords();
        window.location.href = 'Informations/Informations' + '/' + rowInformation[0].Id;
    }

    if (args.item.id === 'editFamily') {
        var test = document.getElementById('#Grid')
        var gridFamily = document.getElementById("Grid").ej2_instances[0];
        var rowFamily = gridFamily.getSelectedRecords();

        window.location.href = 'Family/Family' + '/' + rowFamily[0].Id;
    }

    //if (args.item.id === "collapseall") {
    //    this.groupModule.collapseAll();
    //}
}


// Pregnancy 
$("#pregnancyType").on("change", function () {
    if ($("#pregnancyType option:selected").val() === 'Prématuré') {
        $("#pregnancyRow").hide();
    } else {
        $("#pregnancyRow").show();
    }
});
