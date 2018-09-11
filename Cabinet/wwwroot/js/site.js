function toolbarClickPatient(args) {
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

function toolbarClickConsultation(args) {

    if (args.item.id === 'addConsultation') {

        var gridInformation = document.getElementById("GridConsultation").ej2_instances[0];
        var rowInformation = gridInformation.getSelectedRecords();
        //  window.location = 
        window.location.pathname = "";
        window.location.assign(window.location.origin + '/Consultations/Consultation' + '/' + rowInformation[0].Id);
    }
}

function submitSiblingsGridOnClick(args) {
    var gridSiblings = document.getElementById("GridSiblings").ej2_instances[0];
    $("#GridData").val(JSON.stringify(gridSiblings.dataSource));
}

function girdSiblingsOnCreated(args) {
    var gridInformation = document.getElementById("GridSiblings").ej2_instances[0];
    $("#GridData").val(JSON.stringify(gridInformation.dataSource));
}

//function testClickButton(args) {

//    var gridInformation = document.getElementById("GridSiblings").ej2_instances[0];

//    var siblings = (gridInformation.dataSource);
//    //var form = document.getElementById("formFamily");
//    //var patients = form.dataset;
//    var data = $('#formFamily').serializeArray();
//    // var test = JSON.stringify(siblings);

//    $.ajax({
//        type: 'POST',
//        accepts: 'application/json',
//        url: '/Family/SiblingsFromGrid',
//        contentType: 'application/json',
//        data: JSON.stringify({ ViewModel: data, Siblings: siblings }),
//        error: function (jqXHR, textStatus, errorThrown) {
//            alert('here');
//        },
//        success: function (result) {
//            getData();
//            $('#add-name').val('');
//        }
//    });
//}
 
    //$.ajax({
    //    url: "/Family/Data",
    //    type: "POST",
    //    datatype: "json",
    //    contentType: 'application/json',
    //    data: JSON.stringify({ gid: JSON.stringify(gridInformation.dataSource) }),
    //    success: function (result) {
    //        debugger;
    //    }
    //});  




ej.base.L10n.load({
    // To set the culture globally
   
    'fr': {
        'grid': {
            EmptyRecord: "Aucun patient à afficher",
            GroupDropArea: "Faites glisser un en-tête de colonne ici pour groupe sa colonne",
            DeleteOperationAlert: "Aucun patients sélectionnés pour l'opération de suppression",
            EditOperationAlert: "Aucun patients sélectionnés pour l'opération d'édition",
            SaveButton: "sauvegarder",
            OKButton: "OK",
            CancelButton: "Annuler",
            EditFormTitle: "Les détails de patient ",
            AddFormTitle: "Ajouter un nouvel patient",
            GroupCaptionFormat: "{{:headerText}}: {{:key}} - {{:count}} {{if count == 1 }} article {{else}} articles {{/if}} ",
            BatchSaveConfirm: "Etes-vous sûr que vous voulez enregistrer les modifications?",
            BatchSaveLostChanges: "Les modifications non enregistrées seront perdues. Es-tu sur de vouloir continuer?",
            ConfirmDelete: "Etes-vous sûr de vouloir supprimer le patient?",
            CancelEdit: "Etes-vous sûr que vous voulez annuler les modifications?",
            PagerInfo: "{0} sur {1} pages ({2} patients)",
            FrozenColumnsViewAlert: "colonnes congelés doivent être dans la zone gridview",
            FrozenColumnsScrollAlert: "Activer permettre le défilement, tout en utilisant des colonnes congelés",
            FrozenNotSupportedException: "Les colonnes et les lignes figées sont pas pris en charge pour le regroupement, modèle Row, modèle de Détail, Hiérarchie Grid et Batch Édition",
            Add: "Ajouter",
            Edit: "modifier",
            Delete: "Effacer",
            Update: "Mettre à jour",
            Cancel: "Annuler",
            Done: "Terminé",
            Columns: "colonnes",
            SelectAll: "(Sélectionner tout)",
            PrintGrid: "Impression",
            ExcelExport: "Excel Export",
            WordExport: "parole Export",
            PdfExport: "PDF Export",
            StringMenuOptions: [{ text: "Commence avec", value: "StartsWith" }, { text: "Se termine par", value: "EndsWith" }, { text: "contient", value: "Contains" }, { text: "Égal", value: "Equal" }, { text: "Inequal", value: "NotEqual" }],
            NumberMenuOptions: [{ text: "Moins que", value: "LessThan" }, { text: "Plus grand que", value: "GreaterThan" }, { text: "Inférieur ou equal", value: "LessThanOrEqual" }, { text: "Meilleur que ou equal", value: "GreaterThanOrEqual" }, { text: "Égal", value: "Equal" }, { text: "Inequal", value: "NotEqual" }, { text: "Entre", value: "Between" }],
            PredicateAnd: "ET",
            PredicateOr: "OU",
            Filter: "Filtre",
            FilterMenuCaption: "Valeur du filtre",
            FilterMenuFromCaption: "De",
            FilterMenuToCaption: "À",
            FilterbarTitle: "s bar filtre cellulaire",
            MatchCase: "Cas de correspondance",
            Clear: "Clair",
            ResponsiveFilter: "Filtre",
            ResponsiveSorting: "Trier",
            Search: "Chercher",
            NumericTextBoxWaterMark: "Entrer la valeur",
            DatePickerWaterMark: "Sélectionner une date",
            EmptyDataSource: "DataSource doit pas être vide au chargement initial car les colonnes sont générés à partir dataSource dans AutoGénéré Colonne Grille",
            ForeignKeyAlert: "La valeur mise à jour devrait être une valeur de clé étrangère valide",
            True: "vrai",
            False: "faux",
            UnGroup: "Cliquez ici pour dégrouper",
            AddRecord: "Ajouter un patient",
            EditRecord: "edit patient",
            DeleteRecord: "supprimer le patient",
            Save: "sauvegarder",
            Grouping: "Groupe",
            Ungrouping: "Dissocier",
            SortInAscendingOrder: "Tri par ordre croissant",
            SortInDescendingOrder: "Trier par ordre décroissant",
            NextPage: "Page suivante",
            PreviousPage: "page précédente",
            FirstPage: "Première page",
            LastPage: "Dernière page",
            EmptyRowValidationMessage: "Au moins un champ doit être mis à jour",
            NoResult: "Aucun résultat",
            Item: 'Patient',
            Items: 'Patients'
        },

        'pager': {
            currentPageInfo: "{0} de {1} pages",
            
            totalItemsInfo: '({0} patients)',
            firstPageTooltip: "Aller à la première page",

            lastPageTooltip: "Aller à la dernière page",

            nextPageTooltip: "Aller à la page suivante",

            previousPageTooltip: "Aller à la page précédente",

            nextPagerTooltip: "Aller à la page suivante",

            previousPagerTooltip: "Aller à la page précédente"
        }
    },

    'de-DE': {
        'grid': {
            EmptyRecord: "Keine Aufzeichnungen angezeigt",

            GroupDropArea: "Ziehe Sie einen Spaltenkopf hierher um die Spalten zu gruppieren",

            DeleteOperationAlert: "Für den Löschvorgang wurden keine Datensätze ausgewählt",

            EditOperationAlert: "Für den Bearbeitungsvorgang wurden keine Datensätze ausgewählt",

            SaveButton: "sparen",

            OKButton: "OK",

            CancelButton: "Stornieren",

            EditFormTitle: "Informationen von ",

            AddFormTitle: "Fügen Sie einen neuen Datensatz hinzu",

            GroupCaptionFormat: "{{:headerText}}: {{:key}} - {{:count}} {{if count == 1 }} Artikel {{else}} Artikel {{/if}} ",

            BatchSaveConfirm: "Sind Sie sicher Sie wollen das Speichern?",

            BatchSaveLostChanges: "Ungespeicherte Änderungen gehen verloren. Wollen Sie fortfahren?",

            ConfirmDelete: "Sind Sie sicher Sie wollen diesen Datensatz löschen?",

            CancelEdit: "Sind Sie sicher Sie wollen die Änderungen löschen?",

            PagerInfo: "{0} von {1} Seiten ({2} Beiträge)",

            FrozenColumnsViewAlert: "Fixierte Spalte soll in den Gitternetzansichtsbereich",

            FrozenColumnsScrollAlert: "AllowScrolling erlauben während der Verwendung von fixierten Spalten",

            FrozenNotSupportedException: "Fixierte Spalten und Zeilen werden, für Gruppierungszeilenvorlage, Detailvorlage, Hierachieraster und Stapelbearbeitung nicht unterstützt",

            Add: "Hinzufügen",

            Edit: "Bearbeiten",

            Delete: "Löschen",

            Update: "Aktualisieren",

            Cancel: "Stornieren",

            Done: "Erledigt",

            Columns: "Columns",

            SelectAll: "(Alles auswählen)",

            PrintGrid: "Drucken",

            ExcelExport: "Excel Export",

            WordExport: "Word-Export",

            PdfExport: "PDF-Export",

            StringMenuOptions: [{ text: "Beginnt mit", value: "StartsWith" }, { text: "Endet mit", value: "EndsWith" }, { text: "Enthält", value: "Contains" }, { text: "Gleich", value: "Equal" }, { text: "Nicht equal", value: "NotEqual" }],

            NumberMenuOptions: [{ text: "Weniger als", value: "LessThan" }, { text: "Größer als", value: "GreaterThan" }, { text: "Kleiner als oder equal", value: "LessThanOrEqual" }, { text: "Größer als oder equal", value: "GreaterThanOrEqual" }, { text: "Gleich", value: "Equal" }, { text: "Nicht equal", value: "NotEqual" }, { text: "Zwischen", value: "Between" }],

            PredicateAnd: "UND",

            PredicateOr: "ODER",

            Filter: "Filter",

            FilterMenuCaption: "Filterwert",

            FilterMenuFromCaption: "Von",

            FilterMenuToCaption: "Nach",

            FilterbarTitle: "Filterleiste für Spalte",

            MatchCase: "Kleinschreibung",

            Clear: "Löschen",

            ResponsiveFilter: "Filter",

            ResponsiveSorting: "Sortieren",

            Search: "Suche",

            NumericTextBoxWaterMark: "Geben Sie den Wert ein",

            DatePickerWaterMark: "Select date",

            EmptyDataSource: "Die Quelldaten dürfen bei Inizialisierung nicht leer sein, da die Spalten im AutoGenerierungs Spalten Gitternetz generiert werden",

            ForeignKeyAlert: "Der aktualiserte Wert sollte einen gültiger Fremdschlüsselwert haben",

            True: "wahr",

            False: "falsch",

            UnGroup: "Hier Klicken um Gruppierung aufzuheben",

            AddRecord: "Datensatz hinzufügen",

            EditRecord: "Datensatz bearbeiten",

            DeleteRecord: "Datensatz löschen",

            Save: "sparen",

            Grouping: "Gruppieren",

            Ungrouping: "Gruppierung aufheben",

            SortInAscendingOrder: "Aufsteigend sortieren",

            SortInDescendingOrder: "Absteigend sortieren",

            NextPage: "Nächte Seite",

            PreviousPage: "Vorherige Seite",

            FirstPage: "Erste Seite",

            LastPage: "Letzte Seite",

            EmptyRowValidationMessage: "Zumindestens ein Feld muss aktualisiert werden",

            NoResult: "Keine Treffer gefunden"
        },
        'pager':{
            pagerInfo: "{0} von {1} Seiten ({2} Stück)",

            firstPageTooltip: "Erste Seite",

            lastPageTooltip: "Letzte Seite",

            nextPageTooltip: "Nächste Seite",

            previousPageTooltip: "Vorherige Seite",

            nextPagerTooltip: "Nächste Seitengruppe",

            previousPagerTooltip: "Vorherige Seitengruppe"
        }
    }
});
//ej.base.loadcldr('cldr-data/main/fr/ca-gregorian.json');
//ej.base.setCulture('fr'); 
// copy from https://github.com/syncfusion/ej-global/tree/master/l10n

loadCultureFiles('fr'); 

function loadCultureFiles(name) {
    var files = ['ca-gregorian.json', 'numbers.json', 'timeZoneNames.json'];
    var loader = ej.base.loadCldr;
    var loadCulture = function (prop) {
        var val, ajax;
        //debugger;
        ajax = new ej.base.Ajax(location.origin + location.pathname + './scripts/cldr-data/main/' + name + '/' + files[prop], 'GET', false);
        ajax.onSuccess = function (value) {
            val = value;
        };
        ajax.send();
        loader(JSON.parse(val));
    };
    for (var prop = 0; prop < files.length; prop++) {
        loadCulture(prop);
    }
    ej.base.setCulture(name);
    ej.base.setCurrencyCode('EUR');
} 