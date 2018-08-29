﻿// Write your JavaScript code.

function toolbarClick(args) {

    if (args.item.id === 'editInformations') {
        
        var gridInformation = document.getElementById("Grid").ej2_instances[0];
        var rowInformation = gridInformation.getSelectedRecords();
        window.location.href = 'Informations/Informations' + '/' + rowInformation[0].Id;
    }

    if (args.item.id === 'editFamily') {
        var gridFamily = document.getElementById("Grid").ej2_instances[0];
        var rowFamily = gridFamily.getSelectedRecords();

        window.location.href = 'Family/Index' + '/' + rowFamily[0].Id;
    }

    if (args.item.id === 'editConsultations') {
       
        var gridConsultations = document.getElementById("Grid").ej2_instances[0];
        var rowConsultations = gridConsultations.getSelectedRecords();

        window.location.href = 'Consultations/Index' + '/' + rowConsultations[0].Id;
    }

    //if (args.item.id === "collapseall") {
    //    this.groupModule.collapseAll();
    //}
}


// Pregnancy Value Change

function pregnancyValueChange() {
    var listObj = document.getElementById('pregnancyType').ej2_instances[0];

    var pregnancyRow = document.getElementById('pregnancyRow');

    if (listObj.value !== 'Prématuré') {
        pregnancyRow.hidden = true;
    } else {
        pregnancyRow.hidden = false;
    }
}
