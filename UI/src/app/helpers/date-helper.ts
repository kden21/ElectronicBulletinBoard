export abstract class DateHelper {
  static readonly monthNames = ["января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря"];

  public static castDate(date: string | undefined){
    if (date){
      let d = new Date(date);
      return `${d.getDate()} ${this.monthNames[d.getMonth()]} ${d.getFullYear()}`
    }
    else
      return date;
  }

  public static castDateWithTime(date: string | undefined){
    if (date){
      let d = new Date(date);
      return `${d.getDate()}.${d.getMonth()+1}.${d.getFullYear()} ${String(d.getHours()).padStart(2, '0')}:${String(d.getMinutes()).padStart(2, '0')}`
    }
    else
      return date;
  }
}
