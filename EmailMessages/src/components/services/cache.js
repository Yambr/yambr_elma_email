function isLocalStorageEnabled() {
  try {
    return ('localStorage' in window && window['localStorage'] !== null && localStorage);
  } catch (e) {
    return false;
  }
};

function localStorageSet(key, obj, timeoutMinutes) {
  if (!this.isLocalStorageEnabled())
    return;
  let cachedObject = {
    data: obj
  }
  if (timeoutMinutes) {
    cachedObject.expiry = new Date(new Date().getTime() + timeoutMinutes * 60 * 1000).getTime()
  }
  localStorage.setItem(key, JSON.stringify(cachedObject));
}

function localStorageGet(key) {
  if (!this.isLocalStorageEnabled())
    return null;
  try {
    let cachedObject = JSON.parse(localStorage.getItem(key));
    if (cachedObject.expiry) {
      let currentDate = new Date().getTime();
      if (cachedObject.expiry >= currentDate) {
        return cachedObject.data;
      } else {
        localStorage.removeItem(key);
        return null;
      }
    }
    return cachedObject.data;
  } catch (err) {
    return null;
  }
}

export default {
  isLocalStorageEnabled,
  localStorageGet,
  localStorageSet
}
