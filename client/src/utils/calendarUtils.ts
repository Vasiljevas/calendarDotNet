export const getDaysInMonth = (year: number, month: number) => {
    const date = new Date(year, month, 1);
    let days = 0;
    while (date.getMonth() === month) {
      days++;
      date.setDate(date.getDate() + 1);
    }
    return days;
  };
