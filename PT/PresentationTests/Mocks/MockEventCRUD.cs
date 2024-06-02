using Presentation.Model.API;
using PresentationTests.Mocks;
using Service.API;

namespace PresentationTests.FakeItems
{
    internal class MockEventCRUD : IEventModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockEventCRUD()
        {
        }

        public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
        {
            await this._testRepository.AddEvent(id, stateId, employeeId, customerid, productid);
        }

        public async Task<IEventModel> GetEvent(int id)
        {
            return await this._testRepository.GetEvent(id);
        }

        public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productide)
        {
            await this._testRepository.UpdateEvent(id, stateId, employeeId, customerid, productide);
        }
        
        public async Task DeleteEvent(int id)
        {
            await this._testRepository.DeleteEvent(id);
        }

        public async Task<Dictionary<int, IEventModel>> GetAllEvents()
        {
            Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

            foreach (IEventModel currentEvent in (await this._testRepository.GetAllEvents()).Values)
            {
                result.Add(currentEvent.EventId, (IEventModel)currentEvent);
            }

            return result;
        }

        public async Task<int> GetEventsCount()
        {
            return await this._testRepository.GetEventsCount();
        }
    }
}
