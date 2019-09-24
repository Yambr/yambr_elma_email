import cache from "../services/cache";
import Vue from 'vue'
const baseContractorEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Contractor/";
const contractorEmailRegion = "contractor_email:";

function emailKey(key) {
  return contractorEmailRegion + key;
}

async function fetchContractorEmail(id, from, to, skip, size, key) {
  let url = baseContractorEmailUri + id +
    '?from=' + from +
    '&to=' + to +
    '&skip=' + skip +
    '&size=' + size;
  let data = null;
  if(Vue.config.productionTip){
    const response = await fetch(url);
    if (response.ok) {
      const json = await response.json();
      data = json;
    }
  }
  else{
    data = demoContractorEmail;
  }
  cache.localStorageSet(key, data, 15);
  return data;
}

async function contractorEmail(id, from, to, skip, size) {
  let key = emailKey(id + from + to + skip + size);
  let cachedResult = cache.localStorageGet(key);
  if (cachedResult) {
    return cachedResult;
  } else {
    return await fetchContractorEmail(id, from, to, skip, size, key);
  }
}

export default {
  contractorEmail
}

const demoContractorEmail = {
  messages: [
    {
      from: [
        {
          name: "dadata",
          email: "factor@dadata.ru",
          contact: 1,
          user: null
        }
      ],
      to: [
        {
          name: "Ямброськин Н.Г.",
          email: "i@yambr.ru",
          contact: null,
          user: 1
        }
      ],
      date: "2019-09-24T09:20:18.090Z",
      direction: "Incoming",
      mainHeader: "Георгиевич. Мы продолжаем разыгрывать 4 200 000 ₽. Выбрали 10 новых счастливчиков - каждому подарим от 30 000 до 300 000 ₽.",
      subjectWithoutTags: "Разыгрываем 4 200 000 ₽. Этап 2",
      subject: "[Тинькофф] Разыгрываем 4 200 000 ₽. Этап 2",
      owners: [{
        name: "Ямброськин Н.Г.",
        email: "i@yambr.ru",
        user: 1
      }]
    },
    {
      from: [
        {
          name: "Ямброськин Н.Г.",
          email: "elma@yambr.ru",
          contact: null,
          user: 1
        }
      ],
      to: [
        {
          name: "dadata",
          email: "factor@dadata.ru",
          contact: 1,
          user: null
        },
      ],
      date: "2019-09-24T09:20:18.090Z",
      direction: "Outcoming",
      mainHeader: "С разделами базы знаний я уже разобрался. Спасибо. Очень нужная информация.",
      subjectWithoutTags: "Re: Предложение о сотрудничестве",
      subject: "Re: Предложение о сотрудничестве",
      owners: [{
        name: "Ямброськин Н.Г.",
        email: "i@yambr.ru",
        user: 1
      }]
    }
  ],
  from: 1569316459936,
  to: 1571908459936,
  skip: 0,
  size: 100,
  count: 3
};
