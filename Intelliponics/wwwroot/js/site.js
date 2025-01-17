const baseUrl = 'http://localhost:5137/v1';
let currentPage = 1;
let itemsPerPage = 5;
let totalItems = 0;

$(document).ready(function () {
    performInventoryAction('view');
    performHydroponicsAction('view');

});


// =================== INVENTORY LOGIC ===================
function performInventoryAction(action, product) {
    $.ajax({
        url: `${baseUrl}/admin/handleInventory`,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ action: action, product: product, page: currentPage, itemsPerPage: itemsPerPage }),
        success: function (response) {
            switch (action) {
                case 'view':
                    totalItems = response.totalItems;
                    viewProductList(response.products);
                    break;
                case 'create':
                    alert('Product created successfully');
                    addProductToList(response);
                    break;
                case 'update':
                    alert('Product updated successfully');
                    updateProductInList(response);
                    break;
                case 'delete':
                    alert('Product deleted successfully');
                    removeProductFromList(product.ProductID);
                    break;
                default:
                    console.warn('Unknown action:', action);
            }
        },
        error: function (error) {
            console.error('Error performing action:', error);
            alert('An error occurred while performing the action. Please try again.');
        }
    });
}

function changeItemsPerPage() {
    itemsPerPage = parseInt($('#itemsPerPage').val());
    currentPage = 1;
    performInventoryAction('view');
}

function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        performInventoryAction('view');
    }
}

function nextPage() {
    if (currentPage * itemsPerPage < totalItems) {
        currentPage++;
        performInventoryAction('view');
    }
}


function formatDateTime(dateTime) {
    const date = new Date(dateTime); 
    const options = {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        hour12: false,
    };
    return new Intl.DateTimeFormat('en-GB', options).format(date).replace(',', '');
}

function viewProductList(products) {
    $('#inventory-list').empty();

    products.forEach(product => {
        const formattedDate = formatDateTime(product.LastUpdated);

        $('#inventory-list').append(`<tr class="inventory-row" data-id="${product.ProductID}">
            <td>${product.ProductID}</td>
            <td>${product.Name}</td>
            <td>${product.Category}</td>
            <td>${product.UnitInStock}</td>
            <td>${product.ProductAvailable ? 'In Stock' : 'Out of Stock'}</td>
            <td>${formattedDate}</td>
            <td class="inventory-actions">
                <button class="action-btn preview-btn" title="Preview">
                    <i class="fas fa-eye"></i>
                </button>
                <button class="action-btn edit-btn" title="Edit">
                    <i class="fas fa-edit"></i>
                </button>
                <button class="action-btn delete-btn" title="Delete">
                    <i class="fas fa-trash-alt"></i>
                </button>
            </td>
        </tr>`);
    });

    // Update pagination controls
    $('#currentPage').text(currentPage);
}


function addProductToList(product) {


    $('#inventory-list').append(`<tr class="inventory-row" data-id="${product.ProductID}">
        <td>${product.ProductID}</td>
        <td>${product.Name}</td>
        <td>${product.Category}</td>
        <td>${product.UnitInStock}</td>
        <td>${product.ProductAvailable ? 'In Stock' : 'Out of Stock'}</td>
        <td>${createdDateTime}</td>
            <td class="inventory-actions">
                <button class="action-btn preview-btn" title="Preview">
                    <i class="fas fa-eye"></i>
                </button>
                <button class="action-btn edit-btn" title="Edit">
                    <i class="fas fa-edit"></i>
                </button>
                <button class="action-btn delete-btn" title="Delete">
                    <i class="fas fa-trash-alt"></i>
                </button>
            </td>
        </tr>`);
}

function updateProductInList(product) {
    $(`#inventory-list tr[data-id="${product.ProductID}"]`).html(`
        <td>${product.ProductID}</td>
        <td>${product.Name}</td>
        <td>${product.Category}</td>
        <td>${product.UnitInStock}</td>
        <td>${product.ProductAvailable ? 'In Stock' : 'Out of Stock'}</td>
        <td>${product.LastUpdated}</td>
        <td>
            <button>Edit</button>
            <button>Delete</button>
        </td>
    `);
}

function removeProductFromList(productId) {
    $(`#inventory-list tr[data-id="${productId}"]`).remove();
}


// =================== HYDROPONICS LOGIC ===================

function performHydroponicsAction(action, hydroponic) {
    $.ajax({
        url: `${baseUrl}/admin/handleHydroponics`,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ action: action, hydroponic: hydroponic, page: currentPage, itemsPerPage: itemsPerPage }),
        success: function (response) {
            switch (action) {
                case 'view':
                    totalItems = response.totalItems;
                    viewHydroponicList(response.hydroponics);
                    break;
                case 'create':
                    alert('Hydroponic created successfully');
                    addHydroponicToList(response);
                    break;
                case 'update':
                    alert('Hydroponic updated successfully');
                    updateHydroponicInList(response);
                    break;
                case 'delete':
                    alert('Hydroponic deleted successfully');
                    removeHydroponicFromList(hydroponic.HydroponicID);
                    break;
                default:
                    console.warn('Unknown action:', action);
            }
        },
        error: function (error) {
            console.error('Error performing action:', error);
            alert('An error occurred while performing the action. Please try again.');
        }
    });
}

function viewHydroponicList(hydroponics) {
    // Implement the logic to display the list of hydroponics
}

function addHydroponicToList(hydroponic) {
    // Implement the logic to add a hydroponic to the list
}

function updateHydroponicInList(hydroponic) {
    // Implement the logic to update a hydroponic in the list
}

function removeHydroponicFromList(hydroponicID) {
    // Implement the logic to remove a hydroponic from the list
}