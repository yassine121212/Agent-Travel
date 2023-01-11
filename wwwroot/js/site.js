let items = document.querySelectorAll(".carousel .carousel-item");

items.forEach((el) => {
  const minPerSlide = 4;
  let next = el.nextElementSibling;
  for (var i = 1; i < minPerSlide; i++) {
    if (!next) {
      // wrap carousel by using first child
      next = items[0];
    }

    let cloneChild = next.cloneNode(true);
    el.appendChild(cloneChild.children[0]);
    next = next.nextElementSibling;
  }
});

document.addEventListener(
  "DOMContentLoaded",
  (e) => {
    $("#input-datalist").autocomplete();
  },
  false
);
function removeFromCart(itemId) {
  const item = document.getElementById(`item-${itemId}`);
  item.parentNode.removeChild(item);
}
function incrementQuantity(productId) {
  // Récupérer l'élément de panier correspondant au produit
  var cartItem = document.getElementById(productId);

  // Récupérer la quantité actuelle
  var currentQuantity = parseInt(cartItem.getAttribute("data-quantity"));

  // Incrémenter la quantité
  currentQuantity += 1;

  // Mettre à jour la quantité dans le panier
  cartItem.setAttribute("data-quantity", currentQuantity);

  // Mettre à jour l'affichage de la quantité pour l'utilisateur
  var quantityDisplay = cartItem.querySelector(".quantity-display");
  quantityDisplay.textContent = currentQuantity;

  const unitPriceElement = document.getElementById("unit-price");
  const totalPriceElement = document.getElementById("total-price");
  const unitPrice = +unitPriceElement.textContent;
  const totalPrice = currentQuantity * unitPrice;
  totalPriceElement.textContent = totalPrice + "$";
}
function decrementQuantity(productId) {
  // Récupérer l'élément de panier correspondant au produit
  var cartItem = document.getElementById(productId);

  // Récupérer la quantité actuelle
  var currentQuantity = parseInt(cartItem.getAttribute("data-quantity"));

  // s'assurer qu'on ne décrémente pas si la quantité est déjà 0
  if (currentQuantity > 1) {
    // Décrémenter la quantité
    currentQuantity -= 1;

    // Mettre à jour la quantité dans le panier
    cartItem.setAttribute("data-quantity", currentQuantity);

    // Mettre à jour l'affichage de la quantité pour l'utilisateur
    var quantityDisplay = cartItem.querySelector(".quantity-display");
    quantityDisplay.textContent = currentQuantity;
  }
  const unitPriceElement = document.getElementById("unit-price");
  const totalPriceElement = document.getElementById("total-price");
  const unitPrice = +unitPriceElement.textContent;
  const totalPrice = currentQuantity * unitPrice;
  totalPriceElement.textContent = totalPrice + "$";
}
//dd
var cartItems = [];
var isTotalHidden = true;
var mi = {};
function addToCart(item) {
  cartItems.push(item);
  document.getElementById("itemCounter").innerHTML = cartItems.length;
}
