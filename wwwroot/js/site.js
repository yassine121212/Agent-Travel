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
  document.getElementById("itemCounter").innerHTML = itemId;
}

var cartItems = [];
var isTotalHidden = true;
var mi = {};

let cart = [];
//  document.getElementById("itemCounter").innerHTML = cart.length;
function addToCart() {
  const itemOffre = document.getElementById("id_offre").value;
  const itemPicture = document.getElementById("Picture").innerHTML;
  const itemPrice = document.getElementById("price").innerHTML;
  const itemTitle = document.getElementById("title_offre").innerHTML;

  cart.push({
    id_offre: itemOffre,
    pictures: itemPicture,
    offre: itemTitle,
    prices: itemPrice,
  });
  document.getElementById("itemCounter").innerHTML = cart.length;
  displayCart();
  Totalprice();
}

function displayCart() {
  const cartList = document.getElementById("cart");
  cartList.innerHTML = "";
  for (let i = 0; i < cart.length; i++) {
    const cpt = cartList.childElementCount;
    const div1 = document.createElement("div");
    const div2 = document.createElement("div");
    const div3 = document.createElement("div");
    const div = document.createElement("div");
    const div4 = document.createElement("div");
    const div6 = document.createElement("div");
    const div7 = document.createElement("div");
    const btn3 = document.createElement("button");
    const icon3 = document.createElement("i");
    div1.setAttribute("id", `item-${cpt}`);
    div7.setAttribute("id", "unit-price");
    btn3.onclick = function () {
      removeFromCart(cpt);
    };
    div.className = "col-md-2 col-lg-2 col-xl-2";
    div1.className = "card rounded-3 mb-4";
    div2.className = "card-body p-4";
    div3.className = "row d-flex justify-content-between align-items-center";
    div4.className = "col";
    div6.className = "col text-end";
    div7.className = "col text-end";
    btn3.className = "btn btn-default hidden text-danger";
    icon3.className = "fas fa-trash fa-lg";
    div.innerHTML = `${cart[i].pictures}  `;
    div4.innerHTML = `${cart[i].offre}  `;
    div7.innerHTML = `${cart[i].prices}  `;
    div3.appendChild(div);
    div3.appendChild(div4);
    div3.appendChild(div7);
    btn3.appendChild(icon3);
    div6.appendChild(btn3);
    div3.appendChild(div6);
    div2.appendChild(div3);
    div1.appendChild(div2);
    cartList.appendChild(div1);
  }
}
var unitPrice = 0;
function Totalprice() {
  const Price = document.getElementById("unit-price");
  const total = document.getElementById("total-price");
  unitPrice = unitPrice + parseInt(Price.textContent);
  total.textContent = unitPrice + " MAD ";
}
