using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Overlapping
{
    public enum ParticipationType { Player, Referee}
    public class EventParticipant
    {

        private String firstname;
        public String Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        private String lastname;
        public String Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        private String nationality;
        public String Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }
        private DateTime birthdate;
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }
        private int age;
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                age = now.Year - this.Birthdate.Year;
                if (now < Birthdate.AddYears(age))
                {
                    age--;
                }
                return age;
            }
        }

        private bool refereeRegistration;
        public bool RefereeRegistration
        {
            get
            {
                return refereeRegistration;
            }
            set
            {
                refereeRegistration = value;
            }
        }

        private string certificateNumber; 

        public string CertificateNumber
        {
            get
            {
                return certificateNumber;
            }
            set
            {
                certificateNumber = value;
            }
        }

        private bool playerRegistration;
        public bool PlayerRegistration
        {
            get
            {
                return playerRegistration;
            }
            set
            {
                playerRegistration = value;
            }
        }

        private string startingNumber;
        public string StartingNumber
        {
            get
            {
                return startingNumber;
            }
            set
            {
                startingNumber = value;
            }
        }


        private List<ParticipationType> ParticipationTypes = new List<ParticipationType>();
        public EventParticipant(String firstname, String lastname, String nationality, DateTime birthdate, List<ParticipationType> participationTypes, string certificateNumber, string startingNumber)

        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
            this.Birthdate = birthdate;
            this.ParticipationTypes = participationTypes;
            if (ParticipationTypes.Contains(ParticipationType.Player) && ParticipationTypes.Contains(ParticipationType.Referee))
            {
                if (certificateNumber == null || startingNumber == null || (certificateNumber == null && startingNumber == null))
                {
                    throw new Exception("Missing data");
                }
                this.RefereeRegistration = true;
                this.PlayerRegistration = true;
                this.CertificateNumber = certificateNumber;
                this.StartingNumber = startingNumber;
            }
            else if (ParticipationTypes.Contains(ParticipationType.Player) && !ParticipationTypes.Contains(ParticipationType.Referee))
            {
                if (startingNumber == null)
                {
                    throw new Exception("Missing starting number for player");
                }
                    this.PlayerRegistration = true;
                    this.StartingNumber = startingNumber;
            }
            else if (!ParticipationTypes.Contains(ParticipationType.Player) && ParticipationTypes.Contains(ParticipationType.Referee))
            {
                if (certificateNumber == null)
                {
                    throw new Exception("Missing certificate number for referee");
                }
                this.RefereeRegistration = true;
                this.CertificateNumber = certificateNumber;
            }
            else
            {
                throw new Exception("A participant must be either a player or a referee");
            }
        }

        public bool isReferee()
        {
            return refereeRegistration;
        }

        public bool isPlayer()
        {
            return playerRegistration;
        }

        public override string ToString()
        {
            string info = "";

            if (this.isReferee() && this.isPlayer())
            {
                info += "Referee and coach:\n";
            }
            else if (this.isReferee() && !this.isPlayer())
            {
                info += "Referee:\n";
            }
            else info += "Player:\n";

            info += $"Firstname: { this.Firstname}" +
            $"\nLastname: {this.Lastname}" +
            $"\nNationality: {this.Nationality}" +
            $"\nBirthdate: {this.Birthdate}" +
            $"\nAge: {this.Age}";

            if (this.isReferee() && this.isPlayer())
            {
                info += $"\nCertificate number: {this.CertificateNumber}" +
                    $"\nStarting number: {this.StartingNumber}\n";
            }
            else if (this.isReferee() && !this.isPlayer())
            {
                info += $"\nCertificate number: {this.CertificateNumber}\n";
            }
            else info += $"\nStarting number: {this.StartingNumber}\n";

            return info;

        }
    }
}

