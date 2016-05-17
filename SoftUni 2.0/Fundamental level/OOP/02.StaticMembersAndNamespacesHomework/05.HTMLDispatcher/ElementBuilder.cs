namespace _05.HTMLDispatcher
{
    using System;
    using System.Collections.Generic;

    public class ElementBuilder
    {
        private string elementsName;
        private List<string> attribute;
        private List<string> value;
        private string content;

        public ElementBuilder(string elementsName)
        {
            this.elementsName = elementsName;
            value = new List<string>();
            attribute = new List<string>();
        }

        public string ElementsName
        {
            get
            {
                return this.elementsName;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Elements name should not be empty or null!");
                }
            }
        }

        public static string operator *(ElementBuilder element, int number)
        {
            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                result += element.ToString();
            }

            return result;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attribute.Add(attribute);
            this.value.Add(value);
        }

        public void AddContent(string content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            string atributes = string.Empty;
            for (int i = 0; i < this.attribute.Count; i++)
            {
                atributes += this.attribute[i] + "=" + "\"" + this.value[i] + "\"" + " ";
            }

            atributes = atributes.TrimEnd(' ');
            string result = string.Format("<{0} {1}>{2}</{0}>", this.elementsName, atributes, this.content);
            return result;
        }
    }
}