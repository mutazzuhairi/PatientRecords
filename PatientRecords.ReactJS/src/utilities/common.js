import SweetAlert from "sweetalert2";

export default class StringUtil {
  static splitBySeparator = (str, separator) => {
    return str.split(new RegExp(`(.*?${separator})`, 'g')).filter(Boolean);
  };
}
 
export const SweetAlertPopup = (title,text,button="Ok")=>{
  SweetAlert.fire({
    title: title,
    text: text,
    button: button,
  });
}

 