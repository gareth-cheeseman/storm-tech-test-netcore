export const getJson = async url => {
  const response = await fetch(url);
  if (!response.ok) {
    throw response;
  }
  return response.json();
};

export const getBlob = async url => {
  const response = await fetch(url);
  if (!response.ok) {
    throw response;
  }
  console.log(response);
  return response.blob;
};

export const postJson = async (url, body) => {
  const options = {
    method: 'POST',
    body: JSON.stringify(body)
  };
  const response = await fetch(url, options);
  if (!response.ok) {
    throw response;
  }
  return response.json();
};
