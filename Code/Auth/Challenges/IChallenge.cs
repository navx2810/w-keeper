using System.Collections.Generic;

namespace Keeper.Code.Auth.Challenges
{
    public struct ErrorPair
    {
        /// <summary>
        /// The name of the challenge.
        /// </summary>
        /// <returns>The name of the challenge.</returns>
        public string Name { get; set; }
        /// <summary>
        /// The error message displayed to the user.
        /// </summary>
        /// <returns>The error message displayed to the user.</returns>
        public string Msg { get; set; }
    }

    public interface IErrors
    {
        /// <summary>
        /// This method allows the developer to add an error from a challenge.
        /// </summary>
        /// <param name="challenge">The name of the challenge.</param>
        /// <param name="message">The error message displayed to the user.</param>
        void Add(string challenge, string message);
        /// <summary>
        /// This method allows the developer to add an error pair from a challenge.
        /// </summary>
        /// <param name="error"></param>
        void Add(ErrorPair error);
        /// <summary>
        /// This method checks to see if there are any errors.
        /// </summary>
        /// <returns>True if there are any errors, false if there are none,</returns>
        bool HasAny { get; }
        
        /// <summary>
        /// Returns the errors as a formatted response.
        /// </summary>
        /// <returns>The errors as a formatted response.</returns>
        string Response { get; }
    }

    public interface IChallenge
    {
        IErrors Errors { get; }
    }
}