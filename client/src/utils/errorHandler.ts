const handleError = (error: unknown, coldMessage: string) => {
  if (error instanceof Error) {
    alert(error.message);
  } else {
    alert(coldMessage);
  }
};

export default handleError;
