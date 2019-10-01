import Vue from 'vue'
import axios from 'axios'

const baseDeleteEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Delete/";
const baseEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Load/";


function searchEmailUri(type) {
  return "/Yambr.ELMA.Email.Web/EmailMessage/" + type + "Search/";
}

function emailUri(type) {
  return "/Yambr.ELMA.Email.Web/EmailMessage/" + type + "/"
}


async function deleteEmail(id) {
  let url = baseDeleteEmailUri + id;
  let data = null;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }
  let response = await axios.get(url);
  data = response.data;

  return data;
}

async function emailSearch(type, id, searchString, skip, size) {
  let url = searchEmailUri(type) + id +
    '?searchString=' + searchString +
    '&skip=' + skip +
    '&size=' + size;
  let data = null;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }
  let response = await axios.get(url);
  data = response.data;

  return data;
}

async function email(type, id, from, to, skip, size) {
  let fromString = from.toISOString();
  let toString = to.toISOString();
  let url = emailUri(type) + id +
    '?from=' + fromString +
    '&to=' + toString +
    '&skip=' + skip +
    '&size=' + size;
  let data = null;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }
  let response = await axios.get(url);
  data = response.data;

  return data;
}

async function loadEmail(id) {
  let data = null;
  let url = baseEmailUri + id;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }
  let response = await axios.get(url);
  data = response.data;
  return data;
}

export default {
  deleteEmail,
  emailSearch,
  email,
  loadEmail
}

