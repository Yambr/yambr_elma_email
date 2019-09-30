import Vue from 'vue'
import axios from 'axios'

const baseContractorSearchEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/ContractorSearch/";
const baseDeleteEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Delete/";
const baseContractorEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Contractor/";
const baseEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Load/";

async function deleteEmail(id){
  let url = baseDeleteEmailUri + id;
  let data = null;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }
  let response = await axios.get(url);
  data = response.data;

  return data;
}

async function contractorEmailSearch(id, searchString, skip,size){
  let url = baseContractorSearchEmailUri + id +
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

async function contractorEmail(id, from, to, skip, size) {
  let fromString = from.toISOString();
  let toString = to.toISOString();
  let url = baseContractorEmailUri + id +
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
  contractorEmail,
  contractorEmailSearch,
  loadEmail
}

