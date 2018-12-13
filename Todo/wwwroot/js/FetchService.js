export const getJson = url => {
  return fetch(url).then(response => {
    if (!response.ok) {
      throw response;
    }
    return response.json();
  });
};

export const postJson = (url, body) => {
  const options = {
    method: 'POST',
    body: JSON.stringify(body)
  };
  return fetch(url, options).then(response => {
    if (!response.ok) {
      throw response;
    }
    return response.json();
  });
};
