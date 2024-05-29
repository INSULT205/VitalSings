using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalSings.Models
{
    public partial class User
    {
        public double KBJY
        {
            get
            {
                if (GenderId == 1)
                {
                    if (PurposeUser < 0)
                        _KBJY = (double)((10 * Mass + 6.25 * Height - 5 * Age + 5) * this.Lifestyle.LevelValue + PurposeUser);
                    else
                        _KBJY = (double)((10 * Mass + 6.25 * Height - 5 * Age + 5) * this.Lifestyle.LevelValue + PurposeUser);
                }
                else
                {
                    if (PurposeUser < 0)
                        _KBJY = (double)((10 * Mass + 6.25 * Height - 5 * Age - 161) * this.Lifestyle.LevelValue + PurposeUser);
                    else
                        _KBJY = (double)((10 * Mass + 6.25 * Height - 5 * Age - 161) * this.Lifestyle.LevelValue + PurposeUser);
                }
                return _KBJY;
            }
        }
        private double _KBJY;
        private double _protein;
        private double _fats;
        private double _carbohydrates;
        private int _purposeUser;

        public int PurposeUser
        {
            get 
            {
                if (PurposeId == 1)
                {
                    _purposeUser = -500;
                }
                if (PurposeId == 2)
                {
                    _purposeUser = 0;
                }
                if (PurposeId == 3)
                {
                    _purposeUser = 500;
                }
                return _purposeUser; 
            }
        }

        public double Protein
        {
            get
            {
                _protein = _KBJY * 0.3 / 4;
                return _protein;
            }
        }
        public double Fats
        {
            get
            {
                _fats = _KBJY * 0.3 / 9;
                return _fats;
            }
        }
        public double Carbohydrates
        {
            get
            {
                _carbohydrates = _KBJY * 0.4 / 4;
                return _carbohydrates;
            }
        }
    }
}
