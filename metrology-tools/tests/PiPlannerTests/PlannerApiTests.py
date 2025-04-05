import unittest
from src.PiPlanner.server.api.planner import import_data, sync_with_jira

class TestPlannerApi(unittest.TestCase):

    def test_import_data(self):
        response = import_data('test_data.json')
        self.assertEqual(response['status'], 'success')
        self.assertIn('data', response)

    def test_sync_with_jira(self):
        response = sync_with_jira('test_project_id')
        self.assertEqual(response['status'], 'synced')
        self.assertIn('jira_data', response)

if __name__ == '__main__':
    unittest.main()