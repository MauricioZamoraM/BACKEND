using iText.Html2pdf;


public class Html_to_pdf
{
    public get_pdf_out get_pdf(string html_in)
    {
        get_pdf_out Out = new get_pdf_out() { tipo = "error", mensaje = "", archivo = null };
        try
        {
            MemoryStream ms_Out = new MemoryStream();
            ConverterProperties converterProperties = new ConverterProperties();
            HtmlConverter.ConvertToPdf(html_in, ms_Out, converterProperties);
            Out.archivo = ms_Out.ToArray();
            if (Out.archivo.Length > 0) { Out.tipo = "success"; }
        }
        catch (Exception e)
        {
            Out.tipo = "error";
            Out.mensaje = e.ToString();
        }
        return Out;
    }


}


public class get_pdf_out
{
    public string tipo { get; set; } = "";
    public string mensaje { get; set; } = "";
    public byte[]? archivo { get; set; }
}

