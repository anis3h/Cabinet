// Write your JavaScript code.

function toolbarClick(args) {

    if (args.item.id === 'editInformations') {
        
        var grid = document.getElementById("Grid").ej2_instances[0];
        var row = grid.getSelectedRecords();
        window.location.href = 'Informations/Informations' + '/' + row[0].Id;
    }

    if (args.item.id === 'editFamily') {
        var test = document.getElementById('#Grid')
        var grid = document.getElementById("Grid").ej2_instances[0];
        var row = grid.getSelectedRecords();

        window.location.href = 'Family/Family' + '/' + row[0].Id;
    }

    //if (args.item.id === "collapseall") {
    //    this.groupModule.collapseAll();
    //}
}

