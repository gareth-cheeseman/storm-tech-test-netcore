export const blobToDataUrl = blob => {
  const reader = new FileReader();
  reader.readAsDataURL(blob);
  reader.onloadend = () => {
    const base64Data = reader.result;
    return base64Data;
  };
};
