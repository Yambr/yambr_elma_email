import cache from "../services/cache";
import Vue from 'vue'

const baseContractorStatUri = "/Yambr.ELMA.Email.Web/EmailStats/Contractor/";
const contractorStatRegion = "contractor_stat:";

function statKey(key) {
  return contractorStatRegion + key;
}

async function fetchContractorStat(id, key) {
  let url = baseContractorStatUri + id;
  let data = null;
  if(Vue.config.productionTip){
    const response = await fetch(url);
    if (response.ok) {
      const json = await response.json();
      data = json;
    }
  }
  else{
    data = demoContractorStat;
  }

  let chartData = [];
  data.forEach((el, index) => {
    let date = Date.UTC(el.year, el.month-1, 1);
    chartData.push([date, el.count]);
  });

  cache.localStorageSet(key, chartData, 15);
  return chartData;
}

async function contractorStat(id) {
  let key = statKey(id);
  let cachedResult = cache.localStorageGet(key);
  if (cachedResult) {
    return cachedResult;
  } else {
    return await fetchContractorStat(id, key);
  }
}

export default {
  contractorStat
}

const demoContractorStat = [
  {
    "month": 12,
    "year": 2017,
    "count": 1
  },
  {
    "month": 10,
    "year": 2018,
    "count": 4
  },
  {
    "month": 3,
    "year": 2019,
    "count": 1
  },
  {
    "month": 4,
    "year": 2019,
    "count": 9
  },
  {
    "month": 5,
    "year": 2019,
    "count": 19
  },
  {
    "month": 6,
    "year": 2019,
    "count": 64
  },
  {
    "month": 7,
    "year": 2019,
    "count": 99
  },
  {
    "month": 8,
    "year": 2019,
    "count": 33
  },
  {
    "month": 9,
    "year": 2019,
    "count": 27
  }
];
