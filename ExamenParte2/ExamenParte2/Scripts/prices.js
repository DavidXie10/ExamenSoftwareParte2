const extrasPrices = [3950, 2950, 3950];
const extrasItemsNames = ["Spaguetti Supremo", "Big Cookie", "Ensalada Cobb"];
const pricesDetailsTableBodyId = "pricesDetailsTableBody";
let otherItems = [];

function appendTableCellsToRow(row, cells) {
    for (let index = 0; index < cells.length; ++index) {
        let cellElement = document.createElement("td");
        let cellText = document.createTextNode(cells[index]);
        cellElement.appendChild(cellText);
        row.appendChild(cellElement);
    }
}

function addSelectedItemsToTable() {
    let tableBody = document.getElementById(pricesDetailsTableBodyId);
    for (let item in selectedItems) {
        let row = document.createElement("tr");
        let cells = [];
        cells.push(selectedItems[item].Description, "₡" + selectedItems[item].Price, selectedItems[item].Quantity, "₡" + selectedItems[item].Total);
        this.appendTableCellsToRow(row, cells);
        tableBody.append(row);
    }
}

function calculateSubtotalWithoutExtraItems() {
    let subtotal = 0;
    for (let item in selectedItems) {
        subtotal += selectedItems[item].Total;
    }
    return subtotal;
}


function calculateExtraItemsSubtotal() {
    let subtotal = 0;

    for (let item in extrasPrices) {
        let count = parseInt(document.getElementById("extra-" + item).value);
        if (count > 0) {
            subtotal += count * extrasPrices[item];
        }
    }

    return subtotal;
}

function calculateIva(subtotal) {
    return subtotal * 0.13;
}

function addExtrasToTable() {
    let tableBody = document.getElementById(pricesDetailsTableBodyId);
    for (let item in extrasPrices) {
        let quantity = parseInt(document.getElementById("extra-" + item).value);
        console.log("extra-" + item, ": " + quantity);
        if (quantity > 0) {
            let row = document.createElement("tr");
            row.setAttribute("class", "extra");
            let cells = [];
            cells.push(extrasItemsNames[item], "₡" + extrasPrices[item], quantity, "₡" + quantity * extrasPrices[item]);
            this.appendTableCellsToRow(row, cells);
            tableBody.append(row);
        }
    }
}

function main() {
    addSelectedItemsToTable();
    updateTotalTable();
}

function updateTotalTable() {
    deleteExtras();
    addExtrasToTable();

    let subtotalWithoutExtras = calculateSubtotalWithoutExtraItems();
    let extraItemsSubtotal = calculateExtraItemsSubtotal();
    let orderCount = parseInt(document.getElementById("pizzaCount").value);
    let subtotal = subtotalWithoutExtras * orderCount + extraItemsSubtotal;
    let iva = calculateIva(subtotal);
    let total = subtotal + iva;

    setContent("subtotal", "₡" + parseInt(subtotalWithoutExtras + extraItemsSubtotal));
    setContent("subtotalWithExtras", "₡" + subtotal);
    setContent("iva", "₡" + iva);
    setContent("total", "₡" + parseInt(total));
    document.getElementById("totalHidden").value = total;
}

function setContent(id, content) {
    document.getElementById(id).innerHTML = content;
}

function deleteExtras() {
    let elements = document.getElementsByClassName("extra");
    for (let element of elements) {
        element.parentElement.removeChild(element);
    }
}

main();
document.getElementById("productName").value = "pizza personalizada";
