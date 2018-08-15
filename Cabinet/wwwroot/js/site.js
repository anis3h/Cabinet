// Write your JavaScript code.

function toolbarClick(args) {

    if (args.item.id === 'editall') {
        
        var grid = document.getElementById("Grid").ej2_instances[0];
        var row = grid.getSelectedRecords();
        window.location.href = 'Patient/EditPatient' + '/' + row[0].Id;
    }

    if (args.item.id === 'editFamily') {
        var test = document.getElementById('#Grid')
        var grid = document.getElementById("Grid").ej2_instances[0];
        var row = grid.getSelectedRecords();

        window.location.href = 'Patient/EditFamily' + '/' + row[0].Id;
    }

    //if (args.item.id === "collapseall") {
    //    this.groupModule.collapseAll();
    //}
}

