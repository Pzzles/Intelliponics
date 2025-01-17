var addModal = document.getElementById("addModal");
var deleteModal = document.getElementById("deleteModal");

var openModalBtn = document.getElementById("openModalBtn");
var closeButtons = document.getElementsByClassName("close");

openModalBtn.onclick = function () {
    addModal.style.display = "block";
}

for (var i = 0; i < closeButtons.length; i++) {
    closeButtons[i].onclick = function () {
        this.closest('.modal').style.display = "none";
    }
}

window.onclick = function (event) {
    if (event.target == addModal) {
        addModal.style.display = "none";
    } else if (event.target == deleteModal) {
        deleteModal.style.display = "none";
    }
}

document.getElementById("createProductForm").onsubmit = function (event) {
    event.preventDefault();
    var formData = new FormData(this);
    var product = Object.fromEntries(formData.entries());
    product.discount = parseInt(product.discount);
    product.unitInStock = parseInt(product.unitInStock);
    product.unitPrice = parseInt(product.unitPrice);
    product.supplierId = parseInt(product.supplierId);
    product.categoryId = parseInt(product.categoryId);
    product.subCategoryId = parseInt(product.subCategoryId);
    product.productAvailable = formData.get("productAvailable") === "on";
    product.ProductAvailable = formData.get("productAvailable") === "on";

    performInventoryAction('create', product);

    addModal.style.display = "none";
}

// JavaScript to handle the delete confirmation modal
document.querySelectorAll('.delete-btn').forEach(button => {
    button.addEventListener('click', function () {
        const productId = this.closest('tr').dataset.id;
        deleteModal.style.display = 'block';

        document.getElementById('confirmDeleteBtn').onclick = function () {
            performInventoryAction('delete', { ProductID: productId });
            deleteModal.style.display = 'none';
        };

        document.getElementById('cancelDeleteBtn').onclick = function () {
            deleteModal.style.display = 'none';
        };
    });
});



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//var modal = document.getElementById("addModal");

//var btn = document.getElementById("openModalBtn");

//var span = document.getElementsByClassName("close")[0];

//btn.onclick = function () {
//    modal.style.display = "block";
//}

//span.onclick = function () {
//    modal.style.display = "none";
//}

//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//}

//document.getElementById("createProductForm").onsubmit = function (event) {
//    event.preventDefault();
//    var formData = new FormData(this);
//    var product = Object.fromEntries(formData.entries());
//    product.discount = parseInt(product.discount);
//    product.unitInStock = parseInt(product.unitInStock);
//    product.unitPrice = parseInt(product.unitPrice);
//    product.supplierId = parseInt(product.supplierId);
//    product.categoryId = parseInt(product.categoryId);
//    product.subCategoryId = parseInt(product.subCategoryId);
//    product.productAvailable = formData.get("productAvailable") === "on";
//    product.ProductAvailable = formData.get("productAvailable") === "on";

//    performInventoryAction('create', product);

//    modal.style.display = "none";
//}