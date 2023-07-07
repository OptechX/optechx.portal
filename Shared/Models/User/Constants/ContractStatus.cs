using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContractStatus
    {
        /// <summary>
        /// This stage involves gathering information, defining objectives, and understanding the needs and interests of all parties involved.
        /// It may include conducting research, identifying potential risks, and determining negotiation strategies.
        /// </summary>
        [EnumMember(Value = "Preparation")]
        PREPARATION,

        /// <summary>
        /// In this stage, the parties initiate the negotiation process. They may exchange introductions, express their goals and priorities,
        /// and set the tone for the negotiation. This stage often involves establishing a positive and collaborative environment.
        /// </summary>
        [EnumMember(Value = "Opening")]
        OPENING,

        /// <summary>
        /// The discussion stage focuses on exploring and exchanging ideas, positions, and proposals. Parties may present their terms, discuss
        /// key points, address concerns, and seek clarification on various aspects of the contract. This stage often involves active
        /// communication, negotiation, and compromise.
        /// </summary>
        [EnumMember(Value = "Discussion")]
        DISCUSSION,

        /// <summary>
        /// During this stage, parties engage in give-and-take negotiations to reach mutually acceptable terms. They may make offers,
        /// counteroffers, and concessions as they work towards finding common ground. Bargaining often involves exploring alternatives,
        /// considering trade-offs, and finding solutions that meet the interests of both parties.
        /// </summary>
        [EnumMember(Value = "Bargaining")]
        BARGAINING,

        /// <summary>
        /// The closure stage occurs when the parties have reached an agreement on the key terms of the contract. They may summarize and confirm
        /// the agreed-upon terms, document the details, and finalize any remaining issues or contingencies. This stage often includes reviewing
        /// and revising the contract draft to ensure accuracy and completeness.
        /// </summary>
        [EnumMember(Value = "Closure")]
        CLOSURE,

        /// <summary>
        /// Once the contract terms are agreed upon, the execution stage involves the formal signing and implementation of the contract. This
        /// may include obtaining necessary approvals, signatures, and legal reviews. Parties may also establish timelines, responsibilities,
        /// and mechanisms for monitoring and enforcing the contract.
        /// </summary>
        [EnumMember(Value = "Execution")]
        EXECUTION,

        /// <summary>
        /// The status of the contract negotiation is "Cancelled."
        /// </summary>
        [EnumMember(Value = "Cancelled")]
        CANCELLED
    }
}

