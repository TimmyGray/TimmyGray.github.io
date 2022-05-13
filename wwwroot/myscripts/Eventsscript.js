﻿const tablinks = document.getElementsByClassName("nav-link creambrule-link px-1");
const imagecont = document.getElementById("ImageCont");
const fileinput = document.getElementById("inputGroupFile");
const testbut = document.getElementById("inputGroupFileAddon");
testbut.addEventListener("click", DownloadImage);


async function DownloadImage(eventid, eventfiles) {
    alert("Download images");
    const listiimages = new FormData();
    for (var i = 0; i < eventfiles.length; i++) {
        listiimages.append(`imageFiles`, eventfiles[i], `${eventid}`);
    }
    await fetch("/image", {
        method: "POST",
        body: listiimages
    });
    
    

}
fileinput.addEventListener("change", function () {
    if (fileinput.files.length > 3) {
        alert("Можно добавить не более трех фотографий");
        fileinput.value="";
        return;
    }
    for (var i = 0; i < fileinput.files.length; i++) {
        if (fileinput.files[i].type != "image/jpeg") {
            alert("not image");
            fileinput.value = "";
            return;
        }

        const eventimage = document.createElement("img");
        eventimage.src = window.URL.createObjectURL(fileinput.files[i]);
        eventimage.onload = function () {
            window.URL.revokeObjectURL(this.src);
        }
        eventimage.className = "eventimage";
        imagecont.appendChild(eventimage);
       

    }
       
    

});
function Сhange(event) {
    const maintabs = document.querySelectorAll("main");
    for (var num = 0; num < maintabs.length; num++) {
        maintabs[num].className = "disactivetab";
    }

    document.getElementById(event.currentTarget.name).className = "activetab";
    if (event.currentTarget.id === "HistoryClick" && document.getElementById("body").childElementCount == 0) {
        GetEvents();
    }

    if (event.currentTarget.id === "FaqClick") {
        var pagehave = false;
        const pageuls = document.getElementsByClassName("nav collapse faq-ul-minilink-collapse");
        for (let i = 0; i < pageuls.length; i++) {
            if (!pageuls[i].childElementCount == 0) {
                pagehave = true;
                break;
            }
        }
        if (!pagehave) {
            GetPages();
        }

    }

}
for (var tabnum = 0; tabnum < tablinks.length; tabnum++) {
    tablinks[tabnum].onclick = Сhange;
}

const idh = document.getElementById("idh");
const Label = document.getElementById("ModalLabel");
const discribe = document.getElementById("discribe");
const fix = document.getElementById("fix");
const modalcreate = document.getElementById("modalcreate");

var tempevent;

const closebut = document.getElementById("closechanges");

const editbut = document.getElementById("savechanges");
editbut.addEventListener("click", function (e) {
    tempevent.discribeevent = discribe.value;
    tempevent.fixevent = fix.value;
    EditEvent(tempevent.eventId, tempevent.dateofevent, tempevent.nameofasb, tempevent.nameofdevice, tempevent.isserios, tempevent.discribeevent, tempevent.fixevent, tempevent.eventCreator);
    closebut.click();
});

document.forms["eventForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["eventForm"];
    const dateofevent = form.elements["dateofevent"].value;
    const nameofasb = form.elements["nameofasb"].value;
    const nameofdevice = form.elements["nameofdevice"].value;
    const isserios = form.elements["isserios"].value;
    const discribeevent = form.elements["discribeevent"].value;
    const fixevent = form.elements["fixevent"].value;
    CreateEvent(dateofevent, nameofasb, nameofdevice, isserios, discribeevent, fixevent, curlogin);
});


function row(event, num) {

    const tr = document.createElement("tr");

    tr.id = event.eventId;
    tr.className = "pointerrow";
    tr.setAttribute("data-rowid", event.eventId);

    const idTd = document.createElement("td");
    idTd.setAttribute("name", "id");
    idTd.setAttribute("data-bs-toggle", "modal");
    idTd.setAttribute("data-bs-target", "#Modal");
    idTd.append(num);
    tr.append(idTd);

    const dateofeventTd = document.createElement("td");
    dateofeventTd.setAttribute("name", "dateofevent");
    dateofeventTd.setAttribute("data-bs-toggle", "modal");
    dateofeventTd.setAttribute("data-bs-target", "#Modal");
    let datestring = event.dateofevent;
    let correctdate = "";
    for (let i = 0; i < datestring.length; i++) {
        if (datestring[i] === ".") {
            const repl = datestring[i].replace(".", "-");
            correctdate = correctdate + repl;
        }
        else {
            correctdate = correctdate + datestring[i];
        }
    }
    dateofeventTd.append(correctdate);
    tr.append(dateofeventTd);

    const nameofasbTd = document.createElement("td");
    nameofasbTd.setAttribute("name", "nameofasb");
    nameofasbTd.setAttribute("data-bs-toggle", "modal");
    nameofasbTd.setAttribute("data-bs-target", "#Modal");
    nameofasbTd.append(event.nameofasb);
    tr.append(nameofasbTd);

    const nameofdeviceTd = document.createElement("td");
    nameofdeviceTd.setAttribute("name", "nameofdevice");
    nameofdeviceTd.setAttribute("data-bs-toggle", "modal");
    nameofdeviceTd.setAttribute("data-bs-target", "#Modal");
    nameofdeviceTd.append(event.nameofdevice);
    tr.append(nameofdeviceTd);

    const isseriosTd = document.createElement("td");
    isseriosTd.setAttribute("name", "isserios");
    isseriosTd.setAttribute("data-bs-toggle", "modal");
    isseriosTd.setAttribute("data-bs-target", "#Modal");
    isseriosTd.append(event.isserios);
    tr.append(isseriosTd);

    const eventcreator = document.createElement("td");
    eventcreator.setAttribute("name", "eventcreator");
    eventcreator.setAttribute("data-bs-toggle", "modal");
    eventcreator.setAttribute("data-bs-target", "#Modal");
    eventcreator.append(event.eventCreator);
    tr.append(eventcreator);

    const delbutTd = document.createElement("td");
    delbutTd.setAttribute("name", "delbutTd");
    const delbut = document.createElement("a");
    delbut.href = "#";
    delbut.className = "d-flex align-items-center mb-2 mb-lg-0";
    const delbutimg = document.createElement("img");
    delbutimg.src = "Resources/recyclebin.png";
    delbutimg.alt = "";
    delbutimg.height = "35";
    delbutimg.width = "35";

    delbut.append(delbutimg);
    delbut.addEventListener("click", function (e) {
        DeleteEvent(event.eventId);
    });


    delbutTd.append(delbut);

    tr.appendChild(delbutTd);

    tr.addEventListener("click", trclick);



    return tr;
}

function trclick(event) {
    const curtr = event.currentTarget;
    GetEvent(curtr.id);
}

async function EditEvent(eventid, eventDateofevent, eventNameofasb, eventNameofdevice, eventIsserios, eventDiscribeevent, eventFixevent, eventcreator) {
    const response = await fetch("/events", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            eventId: parseInt(eventid, 10),
            dateofevent: eventDateofevent,
            nameofasb: eventNameofasb,
            nameofdevice: eventNameofdevice,
            isserios: eventIsserios,
            discribeevent: eventDiscribeevent,
            fixevent: eventFixevent,
            eventCreator: eventcreator
        })
    });
    if (response.ok === true) {
        const event = await response.json();
        const temptr = document.getElementById(event.eventId);
        const tdupdate = temptr.querySelector("td");
        const num = parseInt(tdupdate.textContent);
        temptr.replaceWith(row(event, num));
        alert("Происшествие обновлено");

    }

}

async function CreateEvent(eventDateofevent, eventNameofasb, eventNameofdevice, eventIsserios, eventDiscribeevent, eventFixevent, eventcreator) {
    
    const response = await fetch("/events", {
        
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            dateofevent: eventDateofevent,
            nameofasb: parseInt(eventNameofasb, 10),
            nameofdevice: eventNameofdevice,
            isserios: eventIsserios,
            discribeevent: eventDiscribeevent,
            fixevent: eventFixevent,
            eventCreator: eventcreator
        })
        
    });
    if (response.ok === true) {
        const event = await response.json();
        const eventfiles = fileinput.files;
        if (eventfiles.length != 0) {
            alert("Загрузка фотографий");
            DownloadImage(event.eventId, eventfiles);
        }
        const tds = document.getElementsByName("id");
        const num = tds.length + 1;
        document.querySelector("tbody").append(row(event, num));
        alert("Происшествие создано");

    }
}

async function GetEvent(id) {
    const response = await fetch("/events/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const event = await response.json();
        tempevent = event;
        idh.textContent = event.eventId;
        Label.textContent = event.nameofdevice;
        discribe.value = event.discribeevent;
        fix.value = event.fixevent;
        modalcreate.textContent = event.eventCreator;
    }
}

async function GetEvents() {

    const response = await fetch("/events", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {

        const events = await response.json();
        let rows = document.querySelector("tbody");
        let i = 0;
        events.forEach(event => {
            const num = ++i;
            rows.append(row(event, num));
        });
    }
}

async function DeleteEvent(id) {
    const response = await fetch("/events/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const event = await response.json();
        document.querySelector("tr[data-rowid='" + event.eventId + "']").remove();
        let tds = document.getElementsByName("id");
        let i = 0;
        tds.forEach(td => {
            td.textContent = `${++i}`;
        });

        alert("Происшествие удалено");
    }
} 