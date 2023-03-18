function setPreferredLang(lang) {
  localStorage.removeItem("lang");
  localStorage.setItem("lang", lang);
}
function getPreferredLang() {
  return localStorage.getItem("lang");
}

function handleLang() {
  const html = document.querySelector("html");
  const selLang = getPreferredLang() ? getPreferredLang() : "en";

  if (selLang == "ar") {
    // if (document.getElementById("css-ltr")) {
    // Do process for the AR screen
    if (document.getElementById("css-ltr"))
      document
        .getElementsByTagName("head")[0]
        .removeChild(document.getElementById("css-ltr"));
    html.setAttribute("lang", "ar");
    html.setAttribute("dir", "rtl");
    loadExtranalfile("css-rtl", "bootstrap.rtl.min.css", "css");
  } else {
    // } else if (document.getElementById("css-rtl")) {
    // Do process for the EN screen
    if(document.getElementById("css-rtl"))
    document
      .getElementsByTagName("head")[0]
      .removeChild(document.getElementById("css-rtl"));
    html.setAttribute("lang", "en");
    html.setAttribute("dir", "ltr");
    loadExtranalfile("css-ltr", "bootstrap.min.css", "css");
  }

  // Reset the language
  $("[data-lang]").each((i, el) => {
    let text = appLang[selLang][$(el).data("lang")];
    if (el.tagName == "INPUT") {
      $(el).attr("placeholder", text);
    } else $(el).text(text);
  });
}

// Init
handleLang();

function swithLang() {
  if (getPreferredLang() && getPreferredLang() == "ar") setPreferredLang("en");
  else setPreferredLang("ar");

  location.reload();
}

function loadExtranalfile(id, fileName, fileType) {
  fileName = "../content/general/css/" + fileName;
  if (fileType == "js") {
    //if filename is a external JavaScript file
    var fileref = document.createElement("script");
    fileref.setAttribute("type", "text/javascript");
    fileref.setAttribute("src", fileName);
  } else if (fileType == "css") {
    //if filename is an external CSS file
    var fileref = document.createElement("link");
    fileref.setAttribute("rel", "stylesheet");
    fileref.setAttribute("type", "text/css");
    fileref.setAttribute("href", fileName);
  }
  if (typeof fileref != "undefined") {
    fileref.setAttribute("id", id);
    document.getElementById("linkBootstrap").after(fileref);
    // document.getElementsByTagName("head")[0].appendChild(fileref);
  }
}

// Product js

var orderList = [];

function handleItemSelection(itemId, cat) {
  var selItem = $("#" + itemId);

  if (selItem) {
    if (selItem.hasClass("active")) {
      selItem.removeClass("active");
      orderList = orderList.filter((li) => li.id != itemId);
    } else {
      selItem.addClass("active");

      var product =
        cat == "fz" ? frozenItems : cat == "fs" ? freshItems : eggItems;

      orderList.push(product.filter((li) => li.id == itemId)[0]);
    }
  }
  setSessionOrder();
}

function handleItemCount(itemId, action) {
  // action = inc | dec
  var countLbl = $("#" + itemId + " " + ".count");
  if (action == "inc") countLbl.text(Number(countLbl.text()) + 1);
  if (action == "dec" && Number(countLbl.text()) != 1)
    countLbl.text(Number(countLbl.text()) - 1);

  orderList.forEach((item) => {
    if (item.id == itemId) {
      item.count = Number(countLbl.text());
    }
  });
  setSessionOrder();
}

function setSessionOrder() {
  sessionStorage.removeItem("orderList");
  sessionStorage.setItem("orderList", JSON.stringify(orderList));
}

function setSessionCustomer(custObject) {
  sessionStorage.removeItem("customer");
  sessionStorage.setItem("customer", JSON.stringify(custObject));
}
function getSessionCustomer() {
  var cust = sessionStorage.getItem("customer");
  if (cust) return JSON.parse(cust);
  else return null;
}
