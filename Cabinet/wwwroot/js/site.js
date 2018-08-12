// Write your JavaScript code.

function toolbarClick(args) {

    if (args.item.id === 'editall') {
        var test = document.getElementById('#Grid')
        var grid = document.getElementById("Grid").ej2_instances[0];
        var row = grid.getSelectedRecords();

        window.location.href = 'Patient/EditPatient' + '/' + 1;
    }
    //if (args.item.id === "collapseall") {
    //    this.groupModule.collapseAll();
    //}
}

