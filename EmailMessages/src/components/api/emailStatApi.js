import Vue from 'vue'
import axios from 'axios'

const baseContractorStatUri = "/Yambr.ELMA.Email.Web/EmailStats/Contractor/";

async function contractorStat(id) {
  let url = baseContractorStatUri + id;
  let data = null;
  if (!Vue.config.productionTip) {
    url = "http://localhost:888" + url;
  }

  let response = await axios.get(url);
  data = response.data;

  let chartData = [];
  for (let index = 0; index < data.length; index++) {
    let el = data[index];
    let date = Date.UTC(el.year, el.month - 1, 1);
    chartData.push([date, el.count]);
  }
  return chartData;
}

export default {
  contractorStat
}

