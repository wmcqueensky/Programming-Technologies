using Presentation.Model.API;
using PresentationTests.Mocks;
using Service.API;

namespace PresentationTests.FakeItems
{
    internal class MockStateCRUD : IStateModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockStateCRUD()
        {
        }


        public async Task AddState(int id, int catalogid, int quantity)
        {
            await _testRepository.AddState(id, catalogid, quantity);
        }

        public async Task<IStateModel> GetState(int id)
        {
            return await this._testRepository.GetState(id);
        }

        public async Task UpdateState(int id, int catalogid, int quantity)
        {
            await _testRepository.UpdateState(id, catalogid, quantity);
        }

        public async Task DeleteState(int id)
        {
            await this._testRepository.DeleteState(id);
        }

        public async Task<Dictionary<int, IStateModel>> GetAllStates()
        {
            Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

            foreach (IStateModel state in (await this._testRepository.GetAllStates()).Values)
            {
                result.Add(state.StateId, (IStateModel)state);
            }

            return result;
        }

        public async Task<int> GetStatesCount()
        {
            return await this._testRepository.GetStatesCount();
        }
    }
}
