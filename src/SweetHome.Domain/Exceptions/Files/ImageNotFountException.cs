using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetHome.Domain.Exceptions.Files;

public class ImageNotFountException : NotFountException
{
    public ImageNotFountException()
    {
        this.TitleMessage = "Изображение не найдено!";
    }
}
