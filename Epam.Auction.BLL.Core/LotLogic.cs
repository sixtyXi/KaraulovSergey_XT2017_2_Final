using Epam.Auction.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;
using Epam.Auction.DAL.Contracts;
using System.IO;
using System.Drawing;

namespace Epam.Auction.BLL.Core
{
    public class LotLogic : ILotLogic
    {
        private ILotDao dal;

        public LotLogic(ILotDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(Lot lot)
        {
            var img = this.ConvertBytesToImage(lot.Image);
            img = img.Resize(250, 500, false);
            lot.Image = this.ConvertImageToBytes(img);
            return dal.Create(lot);
        }

        public bool Delete(Guid lotId)
        {
            try
            {
                return dal.Delete(lotId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Lot Get(Guid lotId)
        {
            try
            {
                return dal.Get(lotId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            return dal.GetAll().ToArray();
        }

        ////возвращает лоты, размещенные юзером, по которым торги продолжаются
        public IEnumerable<Lot> GetActiveLotsByUserIdTimeNow(Guid userId)
        {
            var timeNow = DateTime.Now;
            return dal.GetAll().Where((lot) => lot.UserId == userId && lot.ExpireDate > timeNow).ToArray();
        }


        public IEnumerable<Lot> GetLotsByName(string lotName)
        {
            return dal.GetAll().Where((lot) => lot.Name.ToLower() == lotName.ToLower()).ToArray();
        }

        public IEnumerable<Lot> GetNewLotsByName(string lotName)
        {
            var timeNow = DateTime.Now;
            return this.GetLotsByName(lotName).Where((lot) => lot.ExpireDate > timeNow).ToArray();
        }


        public IEnumerable<Lot> GetLots(int index, int count, out bool end)
        {
            var lotArray = dal.GetAll().ToArray();
            var lots = new List<Lot>();
            if (index >= lotArray.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < count && index < lotArray.Length; i++, index++)
            {
                lots.Add(lotArray[index]);
            }

            end = (index >= lotArray.Length);
            return lots;
        }

        public IEnumerable<Lot> GetNewLots(int index, int count, out bool end)
        {
            var timeNow = DateTime.Now;
            return this.GetLots(index, count, out end).Where((lot) => lot.ExpireDate > timeNow).ToArray();
        }

        private Image ConvertBytesToImage(byte[] imgData)
        {
            using (var ms = new MemoryStream(imgData))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ConvertImageToBytes(Image img)
        {
            ImageConverter imageConverter = new ImageConverter();
            return (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
        }

    }
}
